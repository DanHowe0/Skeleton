﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffDataEntry.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="StaffId" runat="server" Text="StaffId" height="19px" width="96px"></asp:Label>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" style="z-index: 1; left: 373px; top: 35px; position: absolute" Text="Find" />
        <p>
            <asp:TextBox ID="txtStaffId" runat="server" style="z-index: 1; left: 169px; top: 32px; position: absolute; height: 19px" width="96px"></asp:TextBox>
            <asp:Label ID="lblStaffName" runat="server" style="z-index: 1; left: 12px; position: absolute; top: 88px;" Text="Staff Name" height="19px" width="96px"></asp:Label>
        
        
            <asp:TextBox ID="txtStaffName" runat="server" style="z-index: 1; left: 170px; top: 80px; position: absolute; height: 19px" width="96px"></asp:TextBox>
        
        <asp:Label ID="lblDateAdded" runat="server" style="z-index: 1; left: 10px; top: 133px; position: absolute; bottom: 473px; right: 1239px; margin-bottom: 16px;" Text="Date Added" height="19px" width="96px"></asp:Label>
        <asp:TextBox ID="txtDateAdded" runat="server" style="z-index: 1; left: 169px; top: 133px; position: absolute; height: 19px; width: 126px;"></asp:TextBox>
        <asp:Label ID="lblStaffPhoneNumber" runat="server" style="z-index: 1; left: 12px; top: 190px; position: absolute" Text="Staff Phone Number" height="19px" width="96px"></asp:Label>
        <asp:TextBox ID="txtStaffPhoneNumber" runat="server" style="z-index: 1; left: 169px; position: absolute; height: 19px; top: 186px; bottom: 457px;" width="96px"></asp:TextBox>
        <asp:Label ID="lblStaffEmail" runat="server" style="z-index: 1; left: 14px; top: 238px; position: absolute" Text="Staff Email Id" height="19px" width="96px"></asp:Label>
        <asp:TextBox ID="txtStaffEmail" runat="server" style="z-index: 1; left: 168px; top: 239px; position: absolute; height: 19px; width: 203px;"></asp:TextBox>
        
            &nbsp;
        <asp:Label ID="lblStaffAddress" runat="server" style="z-index: 1; left: 14px; top: 285px; position: absolute; width: 96px; right: 1441px;" Text="Staff Address"></asp:Label>
            <asp:TextBox ID="txtStaffAddress" runat="server"  style="z-index: 1; left: 168px; top: 286px; position: absolute; height: 19px" width="96px"></asp:TextBox>
        <asp:CheckBox ID="chkActive" runat="server" style="z-index: 1; left: 141px; top: 344px; position: absolute" Text="Active" />
        
            <asp:Label ID="lblError" runat="server" style="z-index: 1; left: 288px; top: 372px; position: absolute; width: 56px"></asp:Label>
        
        
            &nbsp;</p>
        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" style="z-index: 1; left: 86px; top: 415px; position: absolute" Text="OK" />
        <asp:Button ID="btnCancel" runat="server" style="z-index: 1; left: 162px; top: 415px; position: absolute" Text="Cancel" />
        <p>
            &nbsp;</p>
        <asp:Button ID="btnReturnToMainMenu" runat="server" OnClick="btnReturnToMainMenu_Click" style="z-index: 1; left: 279px; top: 414px; position: absolute; width: 131px" Text="Return To Main Menu" />
    </form>
</body>
</html>
