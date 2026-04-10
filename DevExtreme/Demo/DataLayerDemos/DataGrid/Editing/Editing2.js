$("#grid1").dxDataGrid({
    columns: [{
        caption: 'A',
        columns: ['A1', 'A2', {
            caption: 'A3',
            columns: ['A31', 'A32', {
                caption: 'A33',
                columns: ['A331', 'A332', 'A333']
            }]
        }]
    }]
});
