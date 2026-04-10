let posturl = "https://jsonplaceholder.typicode.com/posts/"

const postStore = new DevExpress.data.ArrayStore({
    key: "id",
    data: []
})
const commentStore = new DevExpress.data.ArrayStore({
    key: "id",
    data: []
})

function loadComments(postid) {
    $.getJSON(posturl + postid + "/comments").done(res => {
        commentStore._array = res
        comment.getDataSource().reload()
    })
}

$.getJSON(posturl).done(res => {
    postStore._array = res

    const savedId = parseInt(sessionStorage.getItem("postId"))
    const savedTitle = sessionStorage.getItem("title")

    const post = $("#post").dxDropDownBox({
        label: "post",
        dataSource: postStore,
        valueExpr: "id",
        displayExpr: "title",
        value: savedId || null,
        onInitialized: function (e) {
            if (savedId && savedTitle) {
                e.component.option("displayValue", savedTitle)
            }
        },
        contentTemplate: function (e) {
            let $finaldiv = $("<div>");

            let selectedPost = null

            const $grid = $("<div>").dxDataGrid({
                dataSource: postStore,
                columns: ["title"],
                selection: { mode: "single" },
                selectedRowKeys: [e.component.option("value")],
                paging: {
                    enabled: true,
                    pageSize: 5, 
                },
                onSelectionChanged: function (s) {
                    selectedPost = s.selectedRowsData[0] || null
                    e.component.option("value", selectedPost?.id)
                    //e.component.close()
                    if (selectedPost) {
                        loadComments(selectedPost.id)
                        sessionStorage.setItem("postId", selectedPost.id)
                        sessionStorage.setItem("title", selectedPost.title)
                    }
                }
            }).appendTo($finaldiv)

            $("<div>").dxButton({
                text: "Add",
                icon: "plus",
                onClick: function () {
                    const newTitle = prompt("Enter new post title:")

                    $.ajax({
                        url: posturl,
                        method: "POST",
                        contentType: "application/json",
                        data: JSON.stringify({ title: newTitle, body: "My", userId: 1 }),
                    }).done(res => {
                        postStore._array.push(res)
                        $grid.dxDataGrid("instance").refresh()
                    })
                }
            }).appendTo($finaldiv)

            
            $("<div>").dxButton({
                text: "Update",
                icon: "edit",
                onClick: function () {
                    const grid = $grid.dxDataGrid("instance")
                    const keys = grid.getSelectedRowKeys()

                    const current = postStore._array.find(p => p.id === keys[0])
                    const newTitle = prompt("Update post title:", current?.title || "")
                    
                    $.ajax({
                        url: posturl + keys[0],
                        method: "PUT",
                        contentType: "application/json",
                        data: JSON.stringify({ ...current, title: newTitle }),
                    }).done(() => {
                        const idx = postStore._array.findIndex(p => p.id === keys[0])
                        postStore._array[idx].title = newTitle
                        grid.refresh()

                        if (e.component.option("value") === keys[0]) {
                            e.component.option("displayValue", newTitle)
                            sessionStorage.setItem("title", newTitle)
                        }
                    })
                }
            }).appendTo($finaldiv)

            $("<div>").dxButton({
                text: "Delete",
                icon: "trash",
                onClick: function () {
                    const grid = $grid.dxDataGrid("instance")
                    const keys = grid.getSelectedRowKeys()
                    
                    $.ajax({
                        url: posturl + keys[0],
                        method: "DELETE",
                    }).done(() => {
                        postStore._array = postStore._array.filter(p => p.id !== keys[0])
                        grid.refresh()

                        if (e.component.option("value") === keys[0]) {
                            e.component.option("value", null)
                            sessionStorage.removeItem("postId")
                            sessionStorage.removeItem("title")
                        }
                    })
                }
            }).appendTo($finaldiv) 

            return $finaldiv;
        },
    }).dxDropDownBox("instance")

    if (savedId) {
        loadComments(savedId)
    }
})

const comment = $("#comment").dxDropDownBox({
    label: "comments",
    dataSource: commentStore,
    valueExpr: "id",
    displayExpr: "name",
    contentTemplate: function (e) {
        return $("<div>").dxDataGrid({
            dataSource: commentStore,
            columns: ["postId", "name"],
            selection: { mode: "single" },
            onSelectionChanged: function (s) {
                e.component.option("value", s.selectedRowsData[0].id)
                e.component.close()
            }
        })
    },
}).dxDropDownBox("instance")