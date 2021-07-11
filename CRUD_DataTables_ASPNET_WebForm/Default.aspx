<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD_DataTables_ASPNET_WebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>CRUD DataTables.js with ASP.NET Web Form</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js" integrity="sha256-VazP97ZCwtekAsvgPBSUwPFKdrwD3unUfSGVYrahUqU=" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenFieldUser" runat="server" />
        <asp:HiddenField ID="HiddenFieldDeletedUser" runat="server" />
        <asp:HiddenField ID="HiddenFieldCity" runat="server" />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <h1 style="text-align: center;">CRUD DataTables.js with ASP.NET Web Form & Bootstrap</h1>
                </div>
            </div>
            <div class="row">
                <button class="btn btn-primary" id="btnAddRow" onclick="return false;">Add Row</button>
                <asp:Button class="btn btn-danger" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="fnSave();" />
            </div>
            <div class="row" runat="server" id="divSuccessAlert" visible="false">
                <div class="col-md-3"></div>
                <div class="alert alert-success col-md-6">
                    Save successfully!
                </div>
                <div class="col-md-3"></div>
            </div>
            <div class="row">
                <table style="width: 100%;" id="dtUser" class="display cell-border">
                    <thead>
                        <tr>
                            <th>No</th>
                            <th style="display: none;">RowId</th>
                            <th>Name</th>
                            <th>Age</th>
                            <th>City</th>
                            <th>Email</th>
                            <th>Joined Date</th>
                            <th style="width: 30px;"></th>
                            <th style="width: 40px;"></th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="./default.js"></script>
</body>
</html>
