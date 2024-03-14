<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LM401001.aspx.cs" Inherits="Pages_LM401001" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CKMates.Graph.LUMExportOpportunityToExcelProcess"
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
                    <px:PXGridColumn DataField="OpportunityID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Subject" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="OwnerID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="BAccountID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CuryProductsAmount" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__WorkGroupID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CloseDate" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__Parentwgid" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LUMCompanyTreeMember__Rootwgid" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Status" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="StageID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CuryID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CuryRawAmount" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Amount" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="ClosingDate" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CloseDate" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRAddress__AddressLine1" Width="200px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRAddress__AddressLine2" Width="200px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRAddress__State_Description" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRAddress__PostalCode" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CreatedByID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CreatedDateTime" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LastModifiedByID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="LastModifiedDateTime" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__ContactID" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__DisplayName" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__Salutation" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__Email" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__WebSite" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__Phone1Type" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="CRContact__Phone1" Width="150px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrPRODHIER"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrOTYPE"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSSTATUS"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSAUTH"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSNEED"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSFIT"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSCOMP"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrSOURCE"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrBUDGET"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAPN"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrBOOKDATE"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrUSECASE"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrMAINREQ"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrPOCAMT"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSBD"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAWSID"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrDEALER"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrAPNID"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrCalculateCuryAmount"></px:PXGridColumn>
                    <px:PXGridColumn DataField="UsrCalculateTWDAmount"></px:PXGridColumn>
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
