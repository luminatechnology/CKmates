<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LM201000.aspx.cs" Inherits="Pages_LM201000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" TypeName="CKMates.Graph.LUMForecastAdjustmentMaint" PrimaryView="Filter" Visible="True" BorderStyle="NotSet">
        <CallbackCommands>
            <px:PXDSCallbackCommand CommitChanges="True" Name="Save" />
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" Width="100%" Height="80px" DataMember="Filter" FilesIndicator="True" ActivityIndicator="True" NotifyIndicator="True" ActivityField="NoteActivity" NoteIndicator="True">
        <Template>
            <px:PXSelector ID="edWorkgroupID" runat="server" DataField="WorkgroupID" AutoRefresh="True" DataSourceID="ds" Width="150px" CommitChanges="True" />
            <px:PXTextEdit ID="edYear" runat="server" DataField="Year" Width="150px" CommitChanges="True" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXSplitContainer ID="SptCont1" runat="server" SkinID="Horizontal" SplitterPosition="150" Height="600px" Panel1MinSize="600" Panel2MinSize="100">
        <AutoSize Container="Window" Enabled="true" MinHeight="100" />
        <Template1>
            <px:PXGrid ID="gridForecast" runat="server" DataSourceID="ds" Width="100%" Height="100%" SkinID="DetailsInTab" Caption="Forecast" SyncPosition="true">
                <Levels>
                    <px:PXGridLevel DataMember="Transactions">
                        <Columns>
                            <px:PXGridColumn DataField="WorkgroupID" Width="100px" />
                            <px:PXGridColumn DataField="Year" Width="100px" />
                            <px:PXGridColumn DataField="Period01" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period02" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period03" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period04" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period05" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period06" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period07" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period08" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period09" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period10" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period11" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="Period12" TextAlign="Right" Width="150px" />
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <Mode AllowUpload="True" AllowAddNew="False" />
                <AutoSize Enabled="True" />
                <AutoCallBack Command="Refresh" Target="gridResult" ActiveBehavior="true">
                    <Behavior RepaintControlsIDs="gridResult" CommitChanges="false" BlockPage="true" />
                </AutoCallBack>
                <ActionBar ActionsText="False" />
            </px:PXGrid>
        </Template1>
<%--        <Template2>
            <px:PXGrid ID="gridResult" runat="server" DataSourceID="ds" Width="100%" SkinID="DetailsInTab" SyncPosition="True">
                <Levels>
                    <px:PXGridLevel DataMember="RollingResult">
                        <Columns>
                            <px:PXGridColumn DataField="ForecastType" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="FinYear" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="WorkGroupID" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod01" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod02" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod03" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod04" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod05" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod06" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod07" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod08" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod09" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod10" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod11" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="DisplayPeriod12" TextAlign="Right" Width="150px" />
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <Mode AllowUpload="False" AllowAddNew="False" AllowDelete="False" AllowDragRows="true" />
                <AutoSize Enabled="True" MinHeight="200" />
                <AutoCallBack></AutoCallBack>
            </px:PXGrid>
        </Template2>--%>
        <AutoSize Enabled="True" />
    </px:PXSplitContainer>
</asp:Content>
