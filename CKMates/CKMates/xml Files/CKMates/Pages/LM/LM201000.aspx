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
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" Width="100%" DataMember="Filter" FilesIndicator="True" ActivityIndicator="True" NotifyIndicator="True" ActivityField="NoteActivity" NoteIndicator="True">
        <Template>
            <px:PXSelector ID="edWorkgroupID" runat="server" DataField="WorkgroupID" AutoRefresh="True" DataSourceID="ds" Width="150px" />
            <px:PXTextEdit ID="edYear" runat="server" DataField="Year" Width="150px" />
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXSplitContainer ID="SptCont1" runat="server" SkinID="Horizontal" SplitterPosition="300" Height="600px" Panel1MinSize="100" Panel2MinSize="100">
        <AutoSize Container="Window" Enabled="true" MinHeight="300" />
        <Template1>
            <px:PXGrid ID="gridForecast" runat="server" DataSourceID="ds" Width="100%" Height="100%" SkinID="Details" Caption="Forecast" SyncPosition="true">
                <Levels>
                    <px:PXGridLevel DataKeyNames="WorkgroupID,Year" DataMember="Transactions">
                        <RowTemplate>
                            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" LabelsWidth="M" ControlSize="XM" />
                            <px:PXSelector ID="edWorkgroupID" runat="server" DataField="WorkgroupID" AllowEdit="True" />
                            <px:PXTextEdit ID="edYear" runat="server" DataField="Year" MaxLength="4" />
                            <px:PXTextEdit ID="edPeriod1" runat="server" DataField="Period1" />
                            <px:PXTextEdit ID="edPeriod2" runat="server" DataField="Period2" />
                            <px:PXTextEdit ID="edPeriod3" runat="server" DataField="Period3" />
                            <px:PXTextEdit ID="edPeriod4" runat="server" DataField="Period4" />
                            <px:PXTextEdit ID="edPeriod5" runat="server" DataField="Period5" />
                            <px:PXTextEdit ID="edPeriod6" runat="server" DataField="Period6" />
                            <px:PXTextEdit ID="edPeriod7" runat="server" DataField="Period7" />
                            <px:PXTextEdit ID="edPeriod8" runat="server" DataField="Period8" />
                            <px:PXTextEdit ID="edPeriod9" runat="server" DataField="Period9" />
                            <px:PXTextEdit ID="edPeriod10" runat="server" DataField="Period10" />
                            <px:PXTextEdit ID="edPeriod11" runat="server" DataField="Period11" />
                            <px:PXTextEdit ID="edPeriod12" runat="server" DataField="Period12" />
                        </RowTemplate>
                        <Columns>
                            <px:PXGridColumn DataField="WorkgroupID" Width="100px" />
                            <px:PXGridColumn DataField="Year" Width="100px" />
                            <px:PXGridColumn DataField="edPeriod1" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod2" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod3" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod4" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod5" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod6" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod7" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod8" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod9" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod10" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod11" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod12" TextAlign="Right" Width="150px" />
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <Mode AllowUpload="True" AllowAddNew="False" />
                <AutoSize Enabled="True" />
                <AutoCallBack Command="Refresh" Target="gridmatl" ActiveBehavior="true">
                    <Behavior RepaintControlsIDs="gridResult" />
                </AutoCallBack>
                <ActionBar ActionsText="False" />
            </px:PXGrid>
        </Template1>
        <%--<Template2>
            <px:PXGrid ID="gridResult" runat="server" DataSourceID="ds" Width="100%" SkinID="DetailsInTab" SyncPosition="True" TabIndex="2600" StatusField="Availability">
                <Levels>
                    <px:PXGridLevel DataKeyNames="WorkgroupID,Year" DataMember="Transactions">
                        <RowTemplate>
                            <px:PXLayoutRule ID="PXLayoutRule2" runat="server" LabelsWidth="M" ControlSize="XM" />
                            <px:PXSelector ID="edWorkgroupID" runat="server" DataField="WorkgroupID" AllowEdit="True" />
                            <px:PXTextEdit ID="edYear" runat="server" DataField="Year" MaxLength="4" />
                            <px:PXTextEdit ID="edPeriod1" runat="server" DataField="Period1" />
                            <px:PXTextEdit ID="edPeriod2" runat="server" DataField="Period2" />
                            <px:PXTextEdit ID="edPeriod3" runat="server" DataField="Period3" />
                            <px:PXTextEdit ID="edPeriod4" runat="server" DataField="Period4" />
                            <px:PXTextEdit ID="edPeriod5" runat="server" DataField="Period5" />
                            <px:PXTextEdit ID="edPeriod6" runat="server" DataField="Period6" />
                            <px:PXTextEdit ID="edPeriod7" runat="server" DataField="Period7" />
                            <px:PXTextEdit ID="edPeriod8" runat="server" DataField="Period8" />
                            <px:PXTextEdit ID="edPeriod9" runat="server" DataField="Period9" />
                            <px:PXTextEdit ID="edPeriod10" runat="server" DataField="Period10" />
                            <px:PXTextEdit ID="edPeriod11" runat="server" DataField="Period11" />
                            <px:PXTextEdit ID="edPeriod12" runat="server" DataField="Period12" />
                        </RowTemplate>
                        <Columns>
                            <px:PXGridColumn DataField="WorkgroupID" Width="100px" />
                            <px:PXGridColumn DataField="Year" Width="100px" />
                            <px:PXGridColumn DataField="edPeriod1" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod2" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod3" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod4" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod5" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod6" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod7" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod8" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod9" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod10" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod11" TextAlign="Right" Width="150px" />
                            <px:PXGridColumn DataField="edPeriod12" TextAlign="Right" Width="150px" />
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <Mode AllowUpload="True" AllowDragRows="true" />
                <AutoSize Enabled="True" MinHeight="200" />
                <AutoCallBack></AutoCallBack>
            </px:PXGrid>
            </Template>
                <autosize enabled="True" />
        </Template2>--%>
    </px:PXSplitContainer>
</asp:Content>
