<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LM201001.aspx.cs" Inherits="Pages_LM201001" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CKMates.Graph.LUMUpdateSalesRollingForecastProcess" PrimaryView="TempTableResult">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid SyncPosition="True" ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="PrimaryInquire" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="TempTableResult">
                <Columns>
                    <px:PXGridColumn DataField="Selected" Type="CheckBox"></px:PXGridColumn>
                    <px:PXGridColumn DataField="ForecastType" />
                    <px:PXGridColumn DataField="WorkGroupID"></px:PXGridColumn>
                    <px:PXGridColumn DataField="FinYear"></px:PXGridColumn>
                    <px:PXGridColumn DataField="SubFinPeriodID"></px:PXGridColumn>
                    <px:PXGridColumn DataField="Amount"></px:PXGridColumn>
                    <px:PXGridColumn DataField="OrderSeq"></px:PXGridColumn>
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150"></AutoSize>
        <ActionBar>
        </ActionBar>
    </px:PXGrid>
</asp:Content>
