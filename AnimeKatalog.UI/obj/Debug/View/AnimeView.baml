   M S B A M L   `   `   `  ????J  FAnimeKatalog.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AnimeKatalog.UI.ViewAnimeKatalog.UI.View  5   	   E'clr-namespace:AnimeKatalog.UI.ViewModelAnimeKatalog.UI.ViewModel  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	   $    AnimeKatalog.UI.View.AnimeView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35c _Infralution.Localization.Wpf, Version=3.3.0.0, Culture=neutral, PublicKeyToken=547ccae517a004b5W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   .local"clr-namespace:AnimeKatalog.UI.View  5   	   0vm'clr-namespace:AnimeKatalog.UI.ViewModel  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	   	     ? Title$  	AnimeView??5   	   $	??640??6   $
??1080??6(    ? DataContext 5      ??    viewModelLocator ?? Source# [   ?? Path$ AnimeViewModel?.??5      ? .+?5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ 
PrimaryMid=?6#   $??16q?65   .??5      ]? .+?5      ??  ?? Orientation$ 
Horizontal=?6   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+?5        $ Standard=?6/   $??8 4 8 4q?6?      CornerRadius$ 2??6Q    K? ZIndex$ 1??6b   $??16 0 0 0q?5      +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth1=?6+   .??5      ? 
 ? ColumnDefinitions
 5      ?? 5   "   $
??Auto ?63   ?? 5   "   $
??Auto ?63   ?? 5   "   $
??Auto ?63   .+?5      ??   MaterialDesignToolButton#???  6%   .??5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=?6:    J? Opacity$	 .56Q?6H   5      ?? 5      -   5        $??TextBoxSearch??5   &   $??1??5   !   $??8 0 0 0q?61   $	??200??6B   $??Center=?6Q   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=?5   !   $??0q?6^   ??5   ;   ?? *SearchAnime+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? Mode$ TwoWay=?)  #MaterialDesignThemes.Wpf.HintAssist   Hint 5   !   0  *Infralution.Localization.Wpf.ResxExtension     ResxName$) #AnimeKatalog.UI.Resourses.Resources??
   Key$ Search??5   ^   ?? 5       #???  6%   $??2??6X   5!      5"      5#      ?? 5$       & "MaterialDesignToolForegroundButton#???  6   $??8 0 0 0q?6Z   $ 0??6k   5%      ? 5&      $	??299??6    $	??101??6,   .+?5'      ?? -   5         ??Name$ Languge??5'   !   $??RU??6O   $??32??6\   $	??144??6h   ?? 5(      -   5        $??3??5(   !   $??32??6.   $	??144??6:   $??8,0,0,0q?6F   ??5)        $) #AnimeKatalog.UI.Resourses.Resources??$
 Info???? 5*      -   5        $??32??5*   !   $	??224??6-   $??8,8,0,0q?6N   y?5+   !   ?? *VisibilityAdminPanel+??5,   !     $ 
AdminPanel??$) #AnimeKatalog.UI.Resourses.Resources???? 5-      $??22??6    $	??239??6,   ???#D40E0Ey?6M   ?? *VisibilityError+??5.   !     $) #AnimeKatalog.UI.Resourses.Resources??$ Error??5/      ? 50      $??3??6    $	??451??6-   .+?51      ?? $??32??6"   $	??144??6.   $??8,0,0,5q?6:   
??????????	#FF673AB7$ Login??53   "   ??6I   ?? *Login+?? 54      $??32??6!   $	??144??6-   $??8,0,0,0q?69   ??6J   ?? *Authorithation+??55   !     $) #AnimeKatalog.UI.Resourses.Resources??$ Login??  56      $??Stretch=?63   $ PrimaryLight=?6O   y?6c   ?? *VisibilityAccount+.??57      ?? $	??127??6$   $??64??60   ??58   $   ?? *SelectedAccount.Image+59      ?? 5:      $??32??6"   $	??144??6.   $??8,0,0,0q?6:   
??????????	#FF673AB7$ Password??5<   "   ??6L   ?? *
Password+?? 5=      $??32??6!   $	??144??6-   $??8,0,0,0q?69   ??6J   ?? *LogOut+??5>   !     $) #AnimeKatalog.UI.Resourses.Resources??$ Logout???? 5?      $??32??6    $	??144??6,   $??16(?68   
?????????5@       ?? *SelectedAccount.Login+y?6J   ?? *VisibilityAccount+5A      5B      5C      5D      ? 5I   
   -   5         ?Name$ GridMenu??5I      $??70??6!   $
??Left=?6,   ???	#FF673AB7$??0,70,0,0q?6^    J? Effect 5J      3  -System.Windows.Media.Effects.DropShadowEffect  5K         
BlurRadius$ 2Q?6#      ShadowDepth$ 1Q?62      Color$ 	#FFAEAEAE??6B   .+?5M      ?? .+?5N      ?? -   5         ??Name$ ListViewMenu??5N      ???	#FF5C99D6$??Disabled=?6H   .@?5O      ?? -   5         ??Name$ ItemHome??5O   #   $??64??65   .	  (System.Windows.Interactivity.Interaction 	  Triggers 5P      /
  )System.Windows.Interactivity.EventTrigger
  5Q       
  	EventName$ Selected??6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5R   "   6  0System.Windows.Interactivity.InvokeCommandAction     CommandParameter$
 Name??6X      Command 68   ?? *SortCommand+6X   5S      .??5U      ?? $ 
Horizontal=?6%   .+?5V        $ FormatTitle=?66   $??25??6I   $??25??6U   $??10q?6`   5W      5X      ?? 5Y      -   5        $ 
ItemCreate??5Y   #   $??60??67    5Z      
  5[      $ Selected??6-   . 5\   "     $
 Year??6X    68   ?? *SortCommand+6X   5]      .??5_      ?? $ 
Horizontal=?6%   .+?5`        $ Alarm=?66   $??25??6C   $??25??6O   $??10q?6Z   5a      5b      ?? 5c      $??60??6#    5d      
  5e      $ Selected??6-   . 5f   "     $
 Star??6X    68   ?? *SortCommand+6X   5g      .??5i      ?? $ 
Horizontal=?6%   .+?5j        $
 Star=?66   $??25??6B   $??25??6N   $??10q?6Y   5k      5l      ?? 5m      $??60??6#    5n      
  5o      $ Selected??6-   . 5p   "     $ Avtor??6X    68   ?? *SortCommand+6X   5q      .??5s      ?? $ 
Horizontal=?6%   .+?5t        $ Account=?66   $??25??6E   $??25??6Q   $??10q?6\   5u      5v      5w      5x      5y      ? 5~   
   $??
75,128,0,0q?6   .+?5      ?? -	   5        $??ListBoxAnime??5      $??0,10,0,0q?6p   ??6*   ?? *Animes+  ?? SelectedItem  6I   ?? *SelectedAnime+??5?      ?? 5?      .R?5?      ?? $??5q?6%   .+?5?      &   MaterialDesignThemes.Wpf.Flipper    MaterialDesignCardFlipper#???  65   $	 Depth0=?5?   %   !   FrontContent! 5?   "   ? 5?   &   " ? RowDefinitions" 5?   *   ?? 5?   .   $	??300 ?6<   ?? 5?   .   $	??140 ?6<   ?? 5?   .   $??50 ?6<   ?? 5?   .   $
??auto ?6<   .+?5?   *     $??Stretch=?6C   $ PrimaryLight=?6_   .??5?   .   ?? $	??200??64   $	??300??6@   ??6M   ?? *ImgURL+5?   +   ?? 5?   *   $??1??65   $??Center=?6B   $??Center=?6_   .+?5?   .   ?? # ??Name$# TitleTextBox??68   $ ?? Padding$$ 5,5,5,5q?6N   $??Center=?6`   $??Center=?5?   1   $??16(?6L   $??Medium"?6Z   $
??Wrap=?5?   G   ??61   ?? *Name+6G   ?? 5?   .   $??Center=?68   $??Center=?6U   ??5?   1   ?? *Year+(  "MaterialDesignThemes.Wpf.RatingBar  5?   .   %  Name$% BasicRatingBar??6G   {?.  &   Value& 6q   ?? *Star+?? 5?   .   $??0,4,0,0q?65   '   FlipCommand#??Z' 5?   1     MaterialDesignFlatButton#??[ 5?   1   ??5?   1     $) #AnimeKatalog.UI.Resourses.Resources??$ Series??5?   1   %  MaterialDesignThemes.Wpf.Badged  5?   .   (   BadgeColorZoneMode$( SecondaryMid=?6l   $y?Visible=?6?   )   Badge) 6D   0  *MaterialDesignThemes.Wpf.PackIconExtension  *Heart+6?   ?? 5?   .   $
??LOVE??65   $??0,4,0,0q?6D   $?? ??6U   {?5?   9   ?? *DataContext.ControlsEnabled+* ?? RelativeSource* ?? *FindAncestor++ ?? AncestorType$+ WindowL?5?   +   5?   '   ,   BackContent, 5?   "   ? 5?   &   $	??500??6+   $	??200??68   " 5?   *   ?? 5?   .   $
??Auto ?6<   ?? 5?   .   $
??Auto ?6<   .+?5?   *     $ SecondaryMid=?6C   $??6q?6W   .??5?   .   ?? $ 
Horizontal=?69   .+?5?   2   ?? #??[ 69   #??Z' 5?   9   $
??Left=?5?   9   .??5?   6     $ 	ArrowLeft=?6N   $??Right=?6_   5?   3   ?? 5?   2   $??8 0 0 0q?6<   $??Center=?6M   ??6h     $) #AnimeKatalog.UI.Resourses.Resources??$ Series??5?   /   5?   +   ? 5?   *   $??1??6/   $	??172??6<   $	??800??6H   $??0,3,0,0q?6U   $??Center=?6f   $	??Top=?5?   -   $??Visible=?6E   " 5?   .   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   ?? 5?   2   $
??auto ?6@   .+?5?   .   ?? ??66   ?? *	SeriesDTO+??5?   2   ?? 5?   6   .R?5?   :   ?? $??5q?6E   .+?5?   >   ?? ??6E   ?? *Number+5?   ;   5?   7   5?   /   5?   +   5?   '   5?      5?      5?      ??5?      ?? 5?      .R?5?      ? 5?      5?      5?      5?      5?      