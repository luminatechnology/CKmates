<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" CodeFile="LM501000.aspx.cs" Inherits="Pages_LM501000" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CKMates.Graph.LUMUnsubscribeProcess"
        PrimaryView="S3FileList">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<%--<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Setup" Width="100%" Height="50px" AllowAutoHide="false">
        <Template>
            <px:PXCheckBox runat="server" ID="edWithAttachment" DataField="WithAttachment" CommitChanges="true"></px:PXCheckBox>
            <px:PXSelector runat="server" ID="edRevision" DataField="Revision" Width="150px"></px:PXSelector>
        </Template>
    </px:PXFormView>
</asp:Content>--%>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid SyncPosition="True" ID="grid" runat="server" DataSourceID="ds" Width="100%" Height="150px" SkinID="Primary" AllowAutoHide="false">
        <Levels>
            <px:PXGridLevel DataMember="S3FileList">
                <Columns>
                    <px:PXGridColumn DataField="Selected" Type="CheckBox" AllowCheckAll="true"></px:PXGridColumn>
                    <px:PXGridColumn DataField="BucketName" Width="200px"></px:PXGridColumn>
                    <px:PXGridColumn DataField="KeyName" Width="200px"></px:PXGridColumn>
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Container="Window" Enabled="True" MinHeight="150" />
        <ActionBar>
        </ActionBar>
    </px:PXGrid>

</asp:Content>
