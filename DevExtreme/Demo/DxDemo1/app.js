
//HELPERS
var currentStep = 1;

function toast(msg, type) {
    DevExpress.ui.notify(
        { message: msg, position: { at: 'top center', my: 'top center', offset: '0 18' }, displayTime: 3000 },
        type || 'info', 3000
    );
}

let department = [
    'Engineering',
    'Marketing & Sales',
    'Human Resources']
let departmentValue = -1;

let jobTitle = {
    0: [
        { id: 1, title: 'Software Engineer' },
        { id: 2, title: 'Senior Developer' },
        { id: 3, title: 'Team Lead' },
        { id: 4, title: 'Project Manager' },
        { id: 5, title: 'UX Designer' },
        { id: 6, title: 'DevOps Engineer' },
        { id: 7, title: 'Data Analyst' },
        { id: 8, title: 'QA Engineer' }
    ],
    1: [
        { id: 1, title: 'Sales Executive' },
        { id: 2, title: 'Marketing Manager' }
    ],
    2: [
        { id: 1, title: 'HR Executive' }
    ]
};

console.log(jobTitle[0])


//STEP 1

$('#firstName').dxTextBox({
        placeholder: 'e.g. Rahul',
        stylingMode: 'outlined',
        maxLength: 30
    })
    .dxValidator({
        validationGroup: 'step1',
        validationRules: [
            { type: 'required', message: 'First name is required.' },
            { type: 'pattern', pattern: /^[A-Za-z ]+$/, message: 'Letters only.' },
        ]
    });

$('#lastName').dxTextBox({
        placeholder: 'e.g. Sharma',
        stylingMode: 'outlined',
        maxLength: 30
    })
    .dxValidator({
        validationGroup: 'step1',
        validationRules: [
            { type: 'required', message: 'Last name is required.' },
            { type: 'pattern', pattern: /^[A-Za-z ]+$/, message: 'Letters only.' }
        ]
    });


$('#dob').dxDateBox({
    placeholder: 'DD/MM/YYYY',
    stylingMode: 'outlined',
    displayFormat: 'dd/MM/yyyy',
    max: new Date(new Date().setFullYear(new Date().getFullYear() - 18)),
    useMaskBehavior: true
}).dxValidator({
    validationGroup: 'step1',
    validationRules: [
        { type: 'required', message: 'Date of birth is required (must be 18+).' }
    ]
});

$('#gender').dxSelectBox({
    items: ['Male', 'Female', 'Non-binary', 'Prefer not to say'],
    placeholder: 'Select gender',
    stylingMode: 'outlined'
}).dxValidator({
    validationGroup: 'step1',
    validationRules: [
        { type: 'required', message: 'Please select a gender.' }
    ]
});

$('#email').dxTextBox({
        placeholder: 'name@company.com',
        stylingMode: 'outlined',
    })
    .dxValidator({
        validationGroup: 'step1',
        validationRules: [
            { type: 'required', message: 'Email is required.' },
            { type: 'email', message: 'Enter a valid email address.' }
        ]
    });

$('#phone').dxTextBox({
        placeholder: '+91 XXXXX XXXXX',
        stylingMode: 'outlined',
        mask:'+\\9\\1 00000 00000',
    })
    .dxValidator({
        validationGroup: 'step1',
        validationRules: [
            { type: 'required', message: 'Phone number is required.' }
        ]
    });

$('#address').dxTextArea({
    placeholder: 'Street, City, State, PIN code',
    stylingMode: 'outlined',
    height: 76,
    autoResizeEnabled: true
});


//STEP 2 
$('#empId').dxTextBox({
        placeholder: 'e.g. EMP-2024-001',
        stylingMode: 'outlined'
    })
    .dxValidator({
        validationGroup: 'step2',
        validationRules: [
            { type: 'required', message: 'Employee ID is required.' }
        ]
    });

$('#jobTitle').dxDropDownBox({
    dataSource: [], // Start empty
    valueExpr: "id",
    displayExpr: "title",
    placeholder: 'e.g. Software Engineer',
    stylingMode: 'outlined',
    contentTemplate: function (e) {
        const value = e.component.option("value");
        const $dataGrid = $("<div>").dxDataGrid({
            // Use the data specific to the selected department
            dataSource: jobTitle[departmentValue] || [],
            columns: ["title"],
            hoverStateEnabled: true,
            selection: { mode: "single" },
            selectedRowKeys: value !== undefined ? [value] : [],
            onSelectionChanged: function (args) {
                const selectedRow = args.selectedRowsData[0];
                if (selectedRow) {
                    e.component.option("value", selectedRow.id);
                }
                e.component.close();
            }
        });

        // Sync grid selection if the value changes externally
        e.component.on("valueChanged", function (args) {
            $dataGrid.dxDataGrid("instance").selectRows(args.value, false);
        });

        return $dataGrid;
    }
}).dxValidator({
    validationGroup: 'step2',
    validationRules: [
        { type: 'required', message: 'Job title is required.' }
    ]
});

$('#department').dxSelectBox({
    items: department,
    placeholder: 'Select department',
    stylingMode: 'outlined',
    onSelectionChanged: function (e) {
        let index = department.indexOf(e.selectedItem);
        departmentValue = index;
        const jobTitleBox = $('#jobTitle').dxDropDownBox("instance");
        
        // Clear previous selection since it might not belong to the new department
        jobTitleBox.reset(); 
        
        // Update the data source so the displayExpr can find the new titles
        jobTitleBox.option("dataSource", jobTitle[departmentValue]);
    }
}).dxValidator({
    validationGroup: 'step2',
    validationRules: [
        { type: 'required', message: 'Department is required.' }
    ]
});

$('#empType').dxRadioGroup({
    items: ['Full-time', 'Part-time', 'Contract', 'Intern'],
    layout: 'horizontal'
}).dxValidator({
    validationGroup: 'step2', validationRules: [
        { type: 'required', message: 'Please select an employment type.' }
    ]
});

$('#joiningDate').dxDateBox({
    placeholder: 'DD/MM/YYYY', stylingMode: 'outlined', displayFormat: 'dd/MM/yyyy'
}).dxValidator({
    validationGroup: 'step2', validationRules: [
        { type: 'required', message: 'Joining date is required.' }
    ]
});

$('#workLocation').dxSelectBox({
    items: ['On-site', 'Remote', 'Hybrid'],
    placeholder: 'Select work mode', stylingMode: 'outlined'
});

$('#salary').dxNumberBox({
    placeholder: '0', stylingMode: 'outlined', format: '₹ #,##0', min: 0
});

$('#manager').dxSelectBox({
    items: ['Anita Desai', 'Rohan Mehta', 'Priya Nair', 'Vikram Shah', 'Deepa Krishnan'],
    placeholder: 'Select manager', stylingMode: 'outlined', searchEnabled: true
});

/* ══════════════════════════════════════
    STEP 3 WIDGETS  —  validationGroup: 'step3'
══════════════════════════════════════ */
$('#skills').dxTagBox({
    items: ['JavaScript', 'TypeScript', 'Python', 'Java', 'C#', 'React', 'Angular', 'Vue',
        'Node.js', 'Django', 'Spring Boot', '.NET', 'SQL', 'MongoDB', 'PostgreSQL',
        'Docker', 'Kubernetes', 'AWS', 'Azure', 'GCP', 'DevOps', 'Figma', 'Photoshop'],
    placeholder: 'Select or type skills…', stylingMode: 'outlined',
    searchEnabled: true, showSelectionControls: true,
    applyValueMode: 'useButtons', acceptCustomValue: true, maxDisplayedTags: 6
}).dxValidator({
    validationGroup: 'step3', validationRules: [
        { type: 'required', message: 'Please add at least one skill.' }
    ]
});

$('#fileUpload').dxFileUploader({
    selectButtonText: 'Choose File',
    labelText: 'or drop files here  (PDF, DOC, DOCX — max 5 MB)',
    multiple: true,
    allowedFileExtensions: ['.pdf', '.doc', '.docx'],
    maxFileSize: 5 * 1024 * 1024,
    uploadMode: 'useForm'
});

$('#notes').dxTextArea({
    placeholder: 'Any additional information about this employee…',
    stylingMode: 'outlined', height: 90, autoResizeEnabled: true
});

$('#agree').dxCheckBox({ value: false })
    .dxValidator({
        validationGroup: 'step3', validationRules: [
            {
                type: 'compare', comparisonType: '===', comparisonTarget: function () { return true; },
                message: 'You must confirm the information is accurate.'
            }
        ]
    });

/* ══════════════════════════════════════
    NAVIGATION  —  goTo(step, goingBack)
══════════════════════════════════════ */
function goTo(step, back) {
    $('#panel' + currentStep).removeClass('active going-back');
    currentStep = step;
    var $p = $('#panel' + step);
    $p.addClass('active');
    if (back) $p.addClass('going-back');

    // Update tracker indicators
    for (var i = 1; i <= 3; i++) {
        $('#st' + i).removeClass('active done');
        if (i < step) $('#st' + i).addClass('done');
        if (i === step) $('#st' + i).addClass('active');
    }
    $('#con1').toggleClass('filled', step > 1);
    $('#con2').toggleClass('filled', step > 2);

    window.scrollTo({ top: 0, behavior: 'smooth' });
}

/* ══════════════════════════════════════
    BUTTONS
══════════════════════════════════════ */

// Step 1 → Next  (validates group 'step1')
$('#btn1Next').dxButton({
    text: 'Next: Employment Details →', cssClass: 'btn-primary',
    onClick: function () {
        //var result = DevExpress.validationEngine.validateGroup('step1');
        //if (!result.isValid) {
        //    toast('Please fix the highlighted errors before continuing.', 'error');
        //    return;
        //}
        goTo(2, false);
    }
});

// Step 2 → Back
$('#btn2Back').dxButton({
    text: '← Back', cssClass: 'btn-secondary',
    onClick: function () { goTo(1, true); }
});

// Step 2 → Next  (validates group 'step2')
$('#btn2Next').dxButton({
    text: 'Next: Skills & Docs →', cssClass: 'btn-primary',
    onClick: function () {
        var result = DevExpress.validationEngine.validateGroup('step2');
        if (!result.isValid) {
            toast('Please fix the highlighted errors before continuing.', 'error');
            return;
        }
        goTo(3, false);
    }
});

// Step 3 → Back
$('#btn3Back').dxButton({
    text: '← Back', cssClass: 'btn-secondary',
    onClick: function () { goTo(2, true); }
});

// Step 3 → Reset All
$('#btn3Reset').dxButton({
    text: 'Reset All', cssClass: 'btn-secondary',
    onClick: function () {
        DevExpress.ui.dialog.confirm('Reset all fields and return to Step 1?', 'Reset Form')
            .done(function (yes) {
                if (!yes) return;
                resetAll();
                goTo(1, true);
                toast('All fields have been reset.', 'info');
            });
    }
});

// Step 3 → Submit  (validates group 'step3')
$('#btn3Submit').dxButton({
    text: 'Register Employee ✓', cssClass: 'btn-success',
    onClick: function () {
        var result = DevExpress.validationEngine.validateGroup('step3');
        if (!result.isValid) {
            toast('Please fix the highlighted errors before submitting.', 'error');
            return;
        }
        submitForm();
    }
});

// Success → Register Another
$('#btnAnother').dxButton({
    text: 'Register Another Employee', cssClass: 'btn-primary',
    onClick: function () {
        resetAll();
        $('#successPanel').removeClass('active');
        goTo(1, true);
    }
});

/* ══════════════════════════════════════
    SUBMIT
══════════════════════════════════════ */
function submitForm() {
    var data = {
        'First Name': $('#firstName').dxTextBox('instance').option('value'),
        'Last Name': $('#lastName').dxTextBox('instance').option('value'),
        'Date of Birth': $('#dob').dxDateBox('instance').option('value'),
        'Gender': $('#gender').dxSelectBox('instance').option('value'),
        'Email': $('#email').dxTextBox('instance').option('value'),
        'Phone': $('#phone').dxTextBox('instance').option('value'),
        'Employee ID': $('#empId').dxTextBox('instance').option('value'),
        'Job Title': $('#jobTitle').dxAutocomplete('instance').option('value'),
        'Department': $('#department').dxSelectBox('instance').option('value'),
        'Employment Type': $('#empType').dxRadioGroup('instance').option('value'),
        'Joining Date': $('#joiningDate').dxDateBox('instance').option('value'),
        'Work Location': $('#workLocation').dxSelectBox('instance').option('value') || '—',
        'Salary': $('#salary').dxNumberBox('instance').option('value')
            ? '₹ ' + Number($('#salary').dxNumberBox('instance').option('value')).toLocaleString('en-IN')
            : '—',
        'Manager': $('#manager').dxSelectBox('instance').option('value') || '—',
        'Skills': (($('#skills').dxTagBox('instance').option('value')) || []).join(', ') || '—'
    };

    console.log('Employee Registration:', data);

    // Build summary
    var html = '';
    Object.keys(data).forEach(function (k) {
        html += '<div class="sum-item"><label>' + k + '</label><span>' + (data[k] || '—') + '</span></div>';
    });
    $('#summaryGrid').html(html);

    // Show success
    $('#panel3').removeClass('active');
    for (var i = 1; i <= 3; i++) $('#st' + i).addClass('done').removeClass('active');
    $('#con1, #con2').addClass('filled');
    $('#successPanel').addClass('active');
    window.scrollTo({ top: 0, behavior: 'smooth' });
}

/* ══════════════════════════════════════
    RESET ALL
══════════════════════════════════════ */
function resetAll() {
    // Step 1
    $('#firstName').dxTextBox('instance').reset();
    $('#lastName').dxTextBox('instance').reset();
    $('#dob').dxDateBox('instance').reset();
    $('#gender').dxSelectBox('instance').reset();
    $('#email').dxTextBox('instance').reset();
    $('#phone').dxTextBox('instance').reset();
    $('#address').dxTextArea('instance').reset();
    // Step 2
    $('#empId').dxTextBox('instance').reset();
    $('#jobTitle').dxAutocomplete('instance').reset();
    $('#department').dxSelectBox('instance').reset();
    $('#empType').dxRadioGroup('instance').reset();
    $('#joiningDate').dxDateBox('instance').reset();
    $('#workLocation').dxSelectBox('instance').reset();
    $('#salary').dxNumberBox('instance').reset();
    $('#manager').dxSelectBox('instance').reset();
    // Step 3
    $('#skills').dxTagBox('instance').reset();
    $('#notes').dxTextArea('instance').reset();
    $('#agree').dxCheckBox('instance').option('value', false);
    // Reset validation highlights for each group
    DevExpress.validationEngine.resetGroup('step1');
    DevExpress.validationEngine.resetGroup('step2');
    DevExpress.validationEngine.resetGroup('step3');
    // Tracker
    for (var i = 1; i <= 3; i++) $('#st' + i).removeClass('done active');
    $('#con1, #con2').removeClass('filled');
}
