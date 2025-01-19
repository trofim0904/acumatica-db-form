<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="DTDB0000.aspx.cs" Inherits="Page_DTDB0000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="DTDatabaseEntry.Graphs.DTDatabaseEntry"
        PrimaryView="Workspace">
        <CallbackCommands>

        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Workspace" Width="100%" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ControlSize="S" ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
	        <px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="Type" ></px:PXTextEdit>
	        <px:PXLayoutRule ControlSize="XXL" runat="server" ID="CstPXLayoutRule4" StartRow="True" ></px:PXLayoutRule>
	        <px:PXTextEdit Height="400" Width="1200" TextMode="MultiLine" runat="server" ID="CstPXTextEdit1" DataField="Input" ></px:PXTextEdit>
	        <px:PXTextEdit Height="400" Width="1200" TextMode="MultiLine" runat="server" ID="CstPXTextEdit2" DataField="Output" ></px:PXTextEdit></Template>
        <AutoSize Container="Window" Enabled="True" MinHeight="200" ></AutoSize>
    </px:PXFormView>
</asp:Content>

