   M S B A M L   `   `   `  ????G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5          FinalProject.World   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:FinalProject     5        N? Title$  World??5	      .??5      ? -   5         ?Name$ MainGrid??5      ???	#FF442A0B$??0,-1,0,1q?6M   .+?5   
   ?? -   5         ??Name$ InsideCaveImage??5      $
??Left=?6)   $	??430??6D   $??	10,10,0,0q?6Q   $	??Top=?6d   $	??780??6|    J? RenderTransformOrigin$ 1.058,-0.374&?6?   $??media/inside cave.png??6?   $
??Fill=?6?   ?? 5   
   $
??Left=?6   $??	10,10,0,0q?6/   $
??Wrap=?6B   $	??Top=?6V   $??29??6n   $	??133??6z   $??20(?6?   ?? 6?   ???	#FF940A0A$?Inside the cave??6?   6?   ?? 5   
   -   5         ??Name$ CottonAmount??5      $
??Left=?6*   $??	13,45,0,0q?6E   $
??Wrap=?6X   $??How to Play:??6l   $	??Top=?6?   
???????$??19??6?   $??74??6?   6?   ?? 5   
   -   5         ??Name$ 
NextButton??5      $??Use Ferterlizer??6%   $
??Left=?6?   $??500,269,0,0q?6Z   $	??Top=?6o   $??75??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ PreviousButton??5      $??Use Moth??6)   $
??Left=?6<   $??500,294,0,0q?6W   $	??Top=?6l   $??75??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ 
DayCounter??5      $
??Left=?6(   $??674,377,0,0q?6C   $
??Wrap=?6X   $
??Day:??6l   $	??Top=?6x   $??20(?6?   
???????$??98??6?   ?? 5   
   -   5        $ 
ExitButton??5      $
??Exit??6%   $
??Left=?64   $??
715,10,0,0q?6O   $	??Top=?6c   $??75??6{   ???	#FFF03838???	#FFF1D8D8???	#FFFFFEFE J? Opacity$	 0.5Q?6?   6?   ?? 5   
   -   5        $ NoteBookButton??5      $??Notebook??6)   $
??Left=?6<   $??	13,69,0,0q?6W   $	??Top=?6j   $??75??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -	   5        $ PlayerIndicator??5      $
??Left=?6-   $??610,147,0,0q?6H   $
??Wrap=?6]   $	??Top=?6r   $??44??6?   $	??170??6?   
?????????6?   ?? *Health+ ?? Mode$ OneWay=? ?? UpdateSourceTrigger$ PropertyChanged=??? 5   
   -
   5        $ StoreButton??5      $??Store??6&   $
??Left=?66   $??500,225,0,0q?6Q   $	??Top=?6f   $??75??6~   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ PlayerEnergyPoints??5      $
??Left=?60   $??630,221,0,0q?6K   $
??Wrap=?6`   $??points:??6t   $	??Top=?6?   $??Times New Roman)?6?   
???????$??81??6?   ?? 5   
   -   5        $ HungerButton??5      $??+??6'   $
??Left=?63   $??606,194,0,0q?6N   $	??Top=?6c   $??31??6{   $??22??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ SleepButton??5      $??+??6&   $
??Left=?62   $??654,194,0,0q?6M   $	??Top=?6b   $??31??6z   $??22??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ HealthButton??5      $??+??6'   $
??Left=?63   $??704,194,0,0q?6N   $	??Top=?6c   $??31??6{   $??22??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ TakeAwayButton??5      $??Harvest Cotton??6)   $
??Left=?6B   $??110,293,0,0q?6]   $	??Top=?6r   $??88??6?   $??22??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5   
   -   5        $ DisplayToUseTest??5      $
??Left=?6.   $??591,269,0,0q?6I   $
??Wrap=?6^   $
??Fert??6r   $	??Top=?6~   $??Times New Roman)?6?   $??16(?6?   
???????$ 0.562,1.211&?6?   $	??181??6?   $??70??6  ?? 5    
   -   5        $ 	AddButton??5       $??
Use Rabbit??6$   $
??Left=?69   $??500,319,0,0q?6T   $	??Top=?6i   $??75??6?   $??22??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 5"   
   -   5        $ 	NamingOne??5"      $
??Left=?6'   $??
24,403,0,0q?6B   $
??Wrap=?6V   $	??Top=?6?   $	??402??6?   $??Times New Roman)?6?   
?????????6j   ?? 	 ?? Path$
	 Name?6?   ?? 5#   
   -   5        $ 	AmountOne??5#      $
??Left=?6'   $??
39,385,0,0q?6B   $
??Wrap=?6V   $	??Top=?6?   $??Times New Roman)?6?   
???????$	??387??6?   ??6j   ?? *Amount+$ OneWay=?$ PropertyChanged=?6?   ?? 5%   
   $
??Left=?6   $??66??6+   $??
10,319,0,0q?67   $	??Top=?6K   $??78??6c   $??media/corn.png??6n   ?? 5&   
   $
??Left=?6   $??63??6+   $??110,317,0,0q?67   $	??Top=?6L   $??77??6d   $??media/cotton.png??6o   ?? 5'   
   $
??Left=?6   $??64??6+   $??210,316,0,0q?67   $	??Top=?6L   $??85??6d   $??media/CornWorm.png??6o   ?? 5(   
   $
??Left=?6   $??62??6+   $??314,316,0,0q?67   $	??Top=?6L   $??80??6d   $??media/CottonWorm.png??6o   ?? 5*   
   -   5        $ 	NamingTwo??5*      $
??Left=?6'   $??
24,245,0,0q?6B   $
??Wrap=?6V   $	??Top=?6?   $??Times New Roman)?6?   
???????$	??402??6?   ??6j   ?? $
	 Name?6?   ?? 5+   
   $
??Left=?6   $??81??6+   $??
24,135,0,0q?67   $	??Top=?6K   $??99??6c   $??media/bat.png??6n   ?? 5,   
   $
??Left=?6   $??69??6+   $??140,147,0,0q?67   $	??Top=?6L   $??79??6d   $??media/hawk.png??6o   ?? 5-   
   $
??Left=?6   $??69??6+   $??224,147,0,0q?67   $	??Top=?6L   $??85??6d   $??media/beetleOne.png??6o   ?? 5.   
   $
??Left=?6   $??72??6+   $??314,144,0,0q?67   $	??Top=?6L   $??80??6d   $??media/beetleTwo.png??6o   ?? 5/   
   -   5        $ 	AmountTwo??5/      $
??Left=?6'   $??
39,225,0,0q?6B   $
??Wrap=?6V   $	??Top=?6?   $??Times New Roman)?6?   
???????$	??387??6?   ??6j   ?? *Amount+$ OneWay=?$ PropertyChanged=?6?   ?? 51   
   -   5        $ HarvestCornButton??51      $??Harvest Corn??6,   $
??Left=?6C   $??
10,292,0,0q?6^   $	??Top=?6r   $??84??6?   ???	#FF9C6D08
??????????	#FF4D3A19$??22??6?   6?   ?? 52   
   -   5        $ HarvestBeetleOne??52      $??Pick Beetle??6+   $
??Left=?6A   $??234,114,0,0q?6\   $	??Top=?6q   $??75??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 53   
   -   5        $ HarvestBeetleTwo??53      $??Pick Beetle??6+   $
??Left=?6A   $??319,114,0,0q?6\   $	??Top=?6q   $??75??6?   ???	#FF9C6D08
??????????	#FF4D3A196?   ?? 54   
   -   5        $ DisplayWeather??54      $
??Left=?6,   $??
303,17,0,0q?6G   $
??Wrap=?6[   $??	TextBlock??6o   $	??Top=?6?   $??Times New Roman)?6?   $??16(?6?   
???????$??22??6?   $	??174??6?   58      59      