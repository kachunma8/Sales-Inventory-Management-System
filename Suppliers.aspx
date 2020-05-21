<%@ Page Title="" Language="C#" MasterPageFile="~/CommonMaster.master" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="InventoryStore.Suppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-wrapper" class="d-flex flex-column">
        <div class="container-fluid">
            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Manage Suppliers</h1>
            <div style="clear: both; padding: 10px 0px 10px 0px">
                <button class="btn-primary btn-Show-Save" btn-save-id="0" type="button">Add Supplier</button>
                <div class="modal fade" id="addSupplierModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="addModalLabel">Add Supplier</h5>
                                <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form runat="server">
                                    <div class="form-group">
                                        <label>Supplier Name</label>
                                        <input type="text" class="form-control" id="txtName" placeholder="Enter Supplier name" />
                                    </div>
                                    <div class="form-group">
                                        <label>Service Charge</label>
                                        <input type="number" class="form-control" id="txtServiceCharge" placeholder="Enter Service Charge" />
                                    </div>
                                    <div class="form-group">
                                        <label>Vat Charge</label>
                                        <input type="number" class="form-control" id="txtVat" placeholder="Enter Vat Charge" />
                                    </div>
                                    <div class="form-group">
                                        <label>Phone</label>
                                        <input type="text" class="form-control" id="txtPhone" placeholder="Enter Phone Number" />
                                    </div>
                                    <div class="form-group">
                                        <label>Address</label>
                                        <input type="text" class="form-control" id="txtAddress" placeholder="Enter Phone Number" />
                                    </div>
                                    <div class="form-group">
                                        <label>Country</label>
                                        <input type="text" class="form-control" id="txtCountry" placeholder="Enter Country" />
                                    </div>
                                    <div class="form-group">
                                        <label>Message</label>
                                        <input type="text" class="form-control" id="txtMessage" placeholder="Enter Message" />
                                    </div>
                                    <div class="form-group">
                                        <label>Currency</label>
                                        <input type="text" class="form-control" id="txtCurrency" placeholder="Enter Currency" />
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                                <a class="btn btn-primary" href="#" id="btnSaveModal">Save</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="deleteSupplierModal" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Delete Confirmation</h5>
                                <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <span>Are you sure want to delete this record?</span>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                                <a class="btn btn-primary" href="#" id="btnDeleteModal">Delete</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- DataTales Example -->
            <div class="card shadow mb-4">
                <div class="card-body">
                    <div class="table-responsive">
                        <%--<asp:GridView ID="dataTable" runat="server" AutoGenerateColumns="false" DataKeyNames="User_Id" CssClass="table table-bordered"
                            OnRowCommand="dataTable_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="Supplier Name" />
                                <asp:BoundField DataField="LastName" HeaderText="Status" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <button class="btn btn-primary" type="button" data-toggle="modal" data-target="#addSupplierModal">Edit</button>
                                        <button class="btn btn-danger">Delete</button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>--%>
                        <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>Supplier Name</th>
                                    <th>Service Charge</th>
                                    <th>Vat</th>
                                    <th>Country</th>
                                    <th>Currency</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script type="text/javascript">

        function openSaveModal(id, that) {
            $("#btnSaveModal").attr('btn-save-id', id);
            if (id > 0) {
                $("#addModalLabel").text("Edit Supplier");
                var model = JSON.parse($(that).attr("btn-save-model"));
                $("#txtName").val(model.Supplier_Name);
                $("#txtServiceCharge").val(model.Service_Charge_Value);
                $("#txtVat").val(model.Vat_Charge_Value);
                $("#txtPhone").val(model.Phone);
                $("#txtAddress").val(model.Address);
                $("#txtCountry").val(model.Country);
                $("#txtMessage").val(model.Message);
                $("#txtCurrency").val(model.Currency);
            }
            else {
                $("#addModalLabel").text("Add Supplier");
                $("#txtName").val("");
                $("#txtServiceCharge").val("");
                $("#txtVat").val("");
                $("#txtPhone").val("");
                $("#txtAddress").val("");
                $("#txtCountry").val("");
                $("#txtMessage").val("");
                $("#txtCurrency").val("");
            }
            $("#addSupplierModal").modal('show');
        }

        function openDeleteConfirmation(id) {
            $("#btnDeleteModal").attr('btn-save-id', id);
            $("#deleteSupplierModal").modal('show');
        }

        $(document).ready(function () {
            loadSuppliers();

            function loadSuppliers() {
                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("Suppliers.aspx/GetSuppliers") %>',
                    data: {},
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        $("#dataTable tbody").html("");
                        if (result && result.d && result.d.length > 0) {
                            for (var i = 0; i < result.d.length; i++) {
                                $("#dataTable tbody").append("<tr>" +
                                    "<td>" + result.d[i].Supplier_Name + "</td>" +
                                    "<td>" + result.d[i].Service_Charge_Value + "</td>" +
                                    "<td>" + result.d[i].Vat_Charge_Value + "</td>" +
                                    "<td>" + result.d[i].Country + "</td>" +
                                    "<td>" + result.d[i].Currency + "</td>" +
                                    "<td><button class='btn btn-primary btn-Show-Save' onclick='openSaveModal(" + result.d[i].Supplier_Id + ",this);' btn-save-model='" + JSON.stringify(result.d[i]) + "'>Edit</button>&nbsp" +
                                    "<button class='btn btn-danger btn-Show-delete' onclick='openDeleteConfirmation(" + result.d[i].Supplier_Id + ");'> Delete</button ></td></tr>");
                            }
                        }
                        else {
                            $("#dataTable tbody").append('<tr><td colspan="3">No records found!</td><td>');
                        }
                        $('#dataTable').DataTable();
                        //alert("We returned: " + JSON.stringify(result));
                    }
                });
            }

            $(".btn-Show-Save").click(function () {
                var rowId = parseInt($(this).attr('btn-save-id'));
                openSaveModal(rowId, $(this));
            });

            $("#btnSaveModal").click(function () {
                var reqData = {
                    id: $(this).attr('btn-save-id'),
                    name: $("#txtName").val(),
                    serviceCharge: $("#txtServiceCharge").val(),
                    vat: $("#txtVat").val(),
                    phone: $("#txtPhone").val(),
                    address: $("#txtAddress").val(),
                    country: $("#txtCountry").val(),
                    message: $("#txtMessage").val(),
                    currency: $("#txtCurrency").val()
                };
                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("Suppliers.aspx/SaveSupplier") %>',
                    data: JSON.stringify(reqData),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        if (result && result.d && result.d == true) {
                            loadSuppliers();
                            alert('Supplier saved succesfully');
                            $("#addSupplierModal").modal('hide');
                        }
                        else {
                            alert('Error Saving! This may because duplicate name.');
                        }
                    }
                });
            });

            $("#btnDeleteModal").click(function () {
                var reqData = {
                    id: $(this).attr('btn-save-id')
                };
                $.ajax({
                    type: "POST",
                    url: '<%= ResolveUrl("Supplier.aspx/DeleteSupplier") %>',
                    data: JSON.stringify(reqData),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        if (result && result.d && result.d == true) {
                            loadSuppliers();
                            $("#deleteSupplierModal").modal('hide');
                        }
                        else {
                            alert('Error Deleting record!');
                        }
                    }
                });
            });
        });

    </script>
</asp:Content>
