<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaoutManagerDemo._Default" %>

<%@ Register Assembly="PlugAI.Web.UI.LayoutManager" Namespace="PlugAI.Web.UI" TagPrefix="PlugAI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Layout Manager Demo</title>
    <style type="text/css">
        html
        {
            overflow: hidden;
        }
        form
        {
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" style="background-color: White;">
        <div id="top" style="background-color: Navy">
            Top</div>
        <div id="left" style="background-color: blue;">
            Left
        </div>
        <div id="fill" style="background-color: Yellow">
            <div id="top1" style="background-color: white">
                Top</div>
            <div id="left1" style="background-color: Gray;">
                Left
            </div>
            <div id="fill1" style="background-color: Black">
                Fill
            </div>
            <div id="right1" style="background-color: Aqua;">
                Right</div>
            <div id="bottom1" style="background-color: Lime;">
                Bottom</div>
        </div>
        <div id="right" style="background-color: green;">
            Right</div>
        <div id="bottom" style="background-color: red;">
            Bottom</div>
    </div>
    <PlugAI:LayoutManager ID="LayoutManager1" runat="server">
        <Items>
            <PlugAI:DockableItem Dock="Fill" ElementID="main" Margin="0,0,0,0" Name="Main">
                <Items>
                    <PlugAI:DockableItem Dock="Top" ElementID="top" Margin="0,0,0,0" Name="Top" Height="50">
                    </PlugAI:DockableItem>
                    <PlugAI:DockableItem Dock="Left" ElementID="left" Margin="0,0,0,0" Name="Left" Width="100">
                    </PlugAI:DockableItem>
                    <PlugAI:DockableItem Dock="Fill" ElementID="fill" Margin="0,0,0,0" Name="Fill">
                        <Items>
                            <PlugAI:DockableItem Dock="Top" ElementID="top1" Margin="0,0,0,0" Name="Top1" Height="50">
                            </PlugAI:DockableItem>
                            <PlugAI:DockableItem Dock="Left" ElementID="left1" Margin="0,0,0,0" Name="Left1"
                                Width="100">
                            </PlugAI:DockableItem>
                            <PlugAI:DockableItem Dock="Fill" ElementID="fill1" Margin="0,0,0,0" Name="Fill1">
                            </PlugAI:DockableItem>
                            <PlugAI:DockableItem Dock="Right" ElementID="right1" Margin="0,0,0,0" Name="Right1"
                                Width="100">
                            </PlugAI:DockableItem>
                            <PlugAI:DockableItem Dock="Bottom" ElementID="bottom1" Height="50" Margin="0,0,0,0"
                                Name="Bottom1">
                            </PlugAI:DockableItem>
                        </Items>
                    </PlugAI:DockableItem>
                    <PlugAI:DockableItem Dock="Right" ElementID="right" Margin="0,0,0,0" Name="Right"
                        Width="100">
                    </PlugAI:DockableItem>
                    <PlugAI:DockableItem Dock="Bottom" ElementID="bottom" Height="50" Margin="0,0,0,0"
                        Name="Bottom">
                    </PlugAI:DockableItem>
                </Items>
            </PlugAI:DockableItem>
        </Items>
    </PlugAI:LayoutManager>
    </form>
</body>
</html>
