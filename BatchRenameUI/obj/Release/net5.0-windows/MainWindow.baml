   M S B A M L   `   `   `  ���� H  DBatchRenameUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BatchRenameUIBatchRenameUI  M IFluent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent     BatchRenameUI.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:BatchRenameUI     7Fluent$clr-namespace:Fluent;assembly=Fluent     _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Batch Rename��$	��610��$
��1000��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���  $��	Open Sans)�.���� .+�  Fluent.Ribbon     Tabs.   Fluent.RibbonTabItem     Header$
 Home��   Groups.   Fluent.RibbonGroupBox  $��Starter��$	��150��.@�  Fluent.Button  -   $��
ButtonDrag��   Header$
 Drag��
���� K�$��
10,10,0,10q�   	LargeIcon 0  *MaterialDesignThemes.Wpf.PackIconExtension     Size 30	   Kind$	 	OpenInApp=�  -   $��ButtonBrowseFiles��$ Browse Files��
���� K�$��
10,10,0,10q�    30$
	 File=�  -   $��ButtonBrowseFolders��$ Browse Folders��
���� K�$��
10,10,0,10q�    30$	 Folder=�  -   $��ButtonRecursiveAdd��$ Browse Recursively��
���� K�$��
10,10,0,10q�    30$	 StackOverflow=�  $��Rename��$	��150��.@�  -   $��ButtonPreview��$ Preview��
���� K�$��	10,10,0,0q�    30$		 Eye=�  -   $��ButtonRename��$ Rename��
���� K�$��	10,10,0,0q�    30$	 FormTextbox=�  -   $��ButtonRenameAndCreateCopy��$ Create a copy��
���� K�$��10,10,10,10q�    30$	 ContentCopy=�� 
 � ColumnDefinitions
 �� $��1* ��� $��2* � � RowDefinitions �� $��* ��� $
��Auto �.+�� $��0��
 �� $��3* ��� $
��Auto �� $��0��
 �� $��3* ��� $
��Auto �.+��� -	    ��Name$ RuleComboBox��$��Center=�$��10,20,10,10q� " MaterialDesignOutlinedComboBox#��[ )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Rule���� -
    ��Name$ 
AddNewRule��$��1�� / +MaterialDesignFloatingActionMiniLightButton#��[ $��	0,10,10,0q�.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��   Kind$ 
PlusCircle=��� $��3�� �� CornerRadius$ 10��._��� 
���� K�$	��350��$��10q�$��10q����� $��List of Rules��
�������.���� -    ��Name$ 	MyListBox��$��Visible=� �� SelectedItem �� *SelectedRule+����  �� 
TargetType" ��  MaterialDesignListBoxItem �� BasedOn# [ .��� 0	  *MaterialDesignThemes.Wpf.ListBoxItemAssist �� Property �@	 ShowSelection �� Value$
 True����  � ��$ Stretch=� �� Triggers P�  P� Property �@J�IsKeyboardFocusWithin P� Value$
 True��. ���  �@��
IsSelected$
 True������ .R�� 
 �� $��* ��� $��* �.+��� $
��Wrap=�$��Center=�$��0������ *.+�� $��1��$��Right=�$��	10,0,10,0q� �� Orientation$ 
Horizontal=�.+��� $ 
PencilEdit��-   #��[ $��0,0,10,0q�.��  $ Pencil=��� $ GarbageDelete��-   #��[ .��  $ Delete=�&
   System.Windows.Controls.DataGrid
  -    
 Name$ GridOfNames��$
��True��$
��Auto=�$
��Auto=�$	��400��$��10q�$��1��$��3�� 
  CanUserAddRows$ False�� 
  AutoGenerateColumns$ False�� 
  SelectionUnit$ FullRow=� 
  SelectionMode$ Extended=����� *Items+���� )  #System.Windows.Controls.DataGridRow"    MaterialDesignDataGridRow# [  P�  �@J�IsKeyboardFocusWithin$
 True��. ���  �@ 
IsSelected$
 True��  
  Columns  4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn!   Header$
! Type��"   Width5  /System.Windows.Controls.DataGridLengthConverter$" * #   HeaderStyle# �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � ��$ Center=���  � ��
 ���� $   CellTemplate$ �� .R��� $��Center=�$
��Wrap=����� *Type+  $! Old Name��$" * # �� "  .���  � ��$ Center=���  � ��
 ���� $ �� .R��� $��Center=�$
��Wrap=����� *	OldName+  $! New Name��$" * # �� "  .���  � ��$ Center=���  � ��
 ���� $ �� .R��� $��Center=�$
��Wrap=����� *	NewName+  $
! Path��$" 2* # �� "  .���  � ��$ Center=���  � ��
 ���� $ �� .R��� $��Center=�$
��Wrap=����� *Path+  $! Delete��$" * # �� "  .���  � ��$ Center=���  � ��
 ���� $ �� .R��� $ 
DeleteItem��-     MaterialDesignIconButton#��[ .��  $��20��$��20��$ Delete=�