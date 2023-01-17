using System;

class ConsoleExpanded
{
  //variables
  static int DFColor=0;
  static int DBColor=0;
  static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

  //methods
  public static void ColorWrite(string Text, string Color1, string Color2)
  {
    SetColor(Color1,Color2);
    Console.Write(Text);
    ResetColor();
  }
  public static void ColorWriteLine(string Text, string Color1, string Color2)
  {
    SetColor(Color1,Color2);
    Console.WriteLine(Text);
    ResetColor();
  }
  
  public static void SetColor(string Color1, string Color2)
  {
    int index_c=0; int stage = 0;
    foreach (var color in colors)
    {
      if (Console.ForegroundColor == color){DFColor=index_c;}
      if (Console.BackgroundColor == color){DBColor=index_c;} index_c++;
    }
    index_c = 0;
    foreach (var color in colors)
    {
      if (Convert.ToString(color) == Color1) {Console.ForegroundColor = colors[index_c]; stage++;}
      if (Convert.ToString(color) == Color2) {Console.BackgroundColor = colors[index_c]; stage++;}
      if (stage >= 2) {break;} index_c++;
    }
  }
  private static void ResetColor(){
    Console.ForegroundColor=colors[DFColor];
    Console.BackgroundColor=colors[DBColor];
  }
}
class Program
{
  public static void Main()
  {
    ConsoleExpanded.ColorWriteLine("Hello","Green","Red");
    Console.Write("Yeah boy");
    ConsoleExpanded.ColorWrite("Hello","Green","Red");
  }
}
