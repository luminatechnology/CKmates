<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LM401002.aspx.cs" Inherits="Pages_LM401002" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CKMates.Graph.LUMExportCallReportProcess"
        PrimaryView="Transactions">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXGrid AllowPaging="True" AdjustPageSize="Auto" SyncPosition="True" ID="TransactionGrid" runat="server" DataSourceID="ds" Width="100%" Height="100%" SkinID="Details" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="Transactions">
                <Columns>
                    <px:PXGridColumn DataField="CROpportunity__OpportunityID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Type" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Subject" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="StartDate" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="DayOfWeek" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="OwnerID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__WorkGroupID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__Parentwgid" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__Rootwgid" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Source" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Subject" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="BAccount__AcctName" Width="150px"></px:PXGridColumn>
                </Columns>
                <RowTemplate>
                </RowTemplate>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
        <ActionBar>
        </ActionBar>
        <Mode AllowDelete="false" AllowUpload="false" AllowAddNew="false" AllowUpdate="false" />
    </px:PXGrid>
</asp:Content>
