<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="LM101000.aspx.cs" Inherits="Pages_LM101000" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="CKMates.Graph.LUMAmazonS3Setup"
        PrimaryView="S3Preference">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXTab DataMember="S3Preference" ID="tab" runat="server" DataSourceID="ds" Height="150px" Style="z-index: 100" Width="100%" AllowAutoHide="false">
        <Items>
            <px:PXTabItem Text="Amazon S3">
                <Template>
                    <px:PXLayoutRule ControlSize="" runat="server" ID="CstPXLayoutRule4" StartGroup="True" GroupCaption="Amazon S3 Settings"></px:PXLayoutRule>
                    <px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="BucketName"></px:PXTextEdit>
                    <px:PXTextEdit runat="server" ID="CstPXTextEdit2" DataField="KeyName"></px:PXTextEdit>
                    <px:PXTextEdit runat="server" ID="CstPXTextEdit3" DataField="AccessKey"></px:PXTextEdit>
                    <px:PXTextEdit runat="server" ID="CstPXTextEdit5" DataField="SecretKey"></px:PXTextEdit>
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="200"></AutoSize>
    </px:PXTab>
</asp:Content>
