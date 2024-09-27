$(document).ready(function () {
    $("#jqgrid").jqGrid({
        url: "/ContactDetails/GetData",
        datatype: "json",
        colNames: ["Id", "Type", "Value"],
        colModel: [{ name: "Id", key: true, hidden: true },
        { name: "Type", editable: true },
        { name: "Value", editable: true }
        ],
        height: "50%",
        caption: "Contact Detail Records",
        //loadonce: true,
        //jsonReader: {
        //    root: function (obj) { return obj; },
        //    repeatitems:false
        //} required when direct object is req without pagination
        pager: "#pager",
        rowNum: 5,
        rowList: [5, 10, 15],
        sortname: 'id',
        sortorder: 'asc',
        viewrecords: true,
        width: "650",
        gridComplete: function () {
            $("#jqgrid").jqGrid('navGrid', '#pager', { edit: true, add: true, del: true, refresh: true },
                {
                    url: "/ContactDetails/Edit",
                    closeAfterEdit: true,
                    width: 650, afterSubmit: function (response, postdata) {
                        var result = JSON.parse(response.responseText);
                        if (result.success) {
                            alert(result.message);
                            return [true];
                        } else {
                            alert(result.message);
                            return [false];
                        }
                    },
                },
                {
                    url: "/ContactDetails/Add",
                    closeAfterAdd: true,
                    width: 600,
                    afterSubmit: function (response, postdata) {
                        var result = JSON.parse(response.responseText);
                        if (result.success) {
                            alert(result.message);
                            return [true];
                        } else {
                            alert(result.message);
                            return [false];
                        }

                    },
                },
                {
                    url: "/ContactDetails/Delete",
                    afterSubmit: function (response, postdata) {
                        var result = JSON.parse(response.responseText);
                        if (result.success) {
                            alert(result.message);
                            return [true];
                        } else {
                            alert(result.message);
                            return [false];
                        }
                    },
                }
            );
        }
    })
})



                  