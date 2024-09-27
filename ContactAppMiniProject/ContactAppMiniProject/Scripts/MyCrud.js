function loadItems() {
    $.ajax({
        url: "/Contact/GetAllContacts",
        type: "GET",
        success: function (response) {
            console.log(response.contacts, response.isAdmin);
            var data = response.contacts;
            var isAdmin = response.isAdmin;
            $("#tblBody").empty();
            $.each(data, function (index, item) {
                var isChecked = item.IsActive ? 'checked' : '';
                var row = `<tr>
                    <td>${item.FirstName}</td>
                    <td>${item.LastName}</td>
                    <td>
                        <input type="checkbox" ${isChecked} onclick="updateStatus(${item.Id}, this)" />
                    </td>`;
                if (!isAdmin) {
                                    row += `<td>
                                                <button onClick="editContact(${item.Id})" value="Edit" class="btn btn-success">Edit</button>
                                            </td>
                                            <td>
                                                <button onClick="deleteRecord(${item.Id})" value="Delete" class="btn btn-danger">Delete</button>
                                            </td>`;
                                } else {
                                    row += `<td></td><td></td>`;
                                }

                                row += `<td>
                                            <button onClick="contactDetails(${item.Id})" value="ContactDetails" class="btn btn-primary">Details</button>
                                        </td>
                                    </tr>`;
                $("#tblBody").append(row);
            });
        },
        error: function () {
            $("#tblBody").empty();
            alert("No data available");
        }
    });
}

function updateStatus(itemId, checkbox) {
    var isActive = checkbox.checked;
    $.ajax({
        url: "/Contact/UpdateStatus",
        type: "POST",
        data: {
            id: itemId,
            isActive: isActive
        },
        success: function () {
            alert("Status updated successfully");
        },
        error: function () {
            alert("Error updating status");
            checkbox.checked = !checkbox.checked;
        }
    });
}

function addNewRecord(newContact) {
    $.ajax({
        url: "/Contact/Add",
        type: "POST",
        data: JSON.stringify(newContact),
        contentType: "application/json; charset=utf-8", 
        dataType: "json",
        success: function (response) {
            if (response.success) {
                alert("New Contact Added");
                loadItems(); 
            }
        },
        error: function () {
            alert("Error adding contact");
        }
    });
}

function getRecord(contactId) {
    $.ajax({
        url: "/Contact/GetContact",
        type: "GET",
        data: { id: contactId },
        success: function (contact) {
            $("#Id").val(contact.Id);
            $("#contactFirstName").val(contact.FirstName); // Correct ID for FirstName input
            $("#contactLastName").val(contact.LastName); // Correct ID for LastName input
            $("#contactIsActive").prop("checked", contact.IsActive); // Correctly set the checkbox
        },
        error: function (err) {
            alert("No such data found");
        }
    });
}


function modifyRecord(modifiedContact) {
    $.ajax({
        url: "/Contact/Edit",
        type: "POST",
        data: modifiedContact,
        success: function (contact) {
            if (contact.success) {
                alert("Contact Modified Successfully")
                loadItems()
            }
        },
        error: function (err) {
            alert("Error modifying record");
        }
    }) }

function deleteRecord(itemId) {
    if (confirm("Do you wish to delete this?")) {
        $.ajax({
            url: "/Contact/Delete",
            type: "POST",
            data: { id: itemId },

            success: function (item) {
                alert("Record deleted successfully")
                loadItems();
            },
            error: function (err) {
                alert("Record does not exist")
            }
        })
    }
}


$("#btnAdd").click(() => {
    $("#contactList").hide();
    $("#newRecord").show();
})

function editContact(contactId) {
    getRecord(contactId);
    $("#contactList").hide();
    $("#editRecord").show();
}

function contactDetails(contactId) {
    // Create a form element dynamically for a POST request
    //var form = $('<form action="/ContactDetails/Index" method="POST">' +
    //    '<input type="hidden" name="contactId" value="' + contactId + '" />' +
    //    '</form>');

    //// Append the form to the body and submit it
    //$('body').append(form);
    //form.submit();
    window.location.href = '/ContactDetails/Index?contactId=' + contactId;

}
