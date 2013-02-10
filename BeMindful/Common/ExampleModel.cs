using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Be_Mindful.Common
{
  public class ExampleModel
  {
    public ExampleModel()
    {
    }

    public ExampleModel(string caption, FrameworkElement control, string exampleKeyword)
      : this()
    {
      this.exampleKeyword = exampleKeyword;
      Caption = caption;
      Control = control;
     // Image = FileHelper.LoadImage("Controls/" + ImageFileName);
    }

    public string Caption { get; set; }
    public FrameworkElement Control { get; set; }
    public ImageSource Image { get; set; }

    private readonly string exampleKeyword;

    private string ImageFileName
    {
      get
      {
        return exampleKeyword + ".png";
      }
    }

    public string XamlFileName
    {
      get
      {
        return exampleKeyword + "Example.xaml";
      }
    }

    public string DescriptionFileName
    {
      get
      {
        return exampleKeyword + ".txt";
      }
    }

    public string SyntaxFileName
    {
      get
      {
        return exampleKeyword + "Syntax.xml";
      }
    }

    public SourceModel CreateSourceModel(string source, string title = "XAML source")
    {
      return new SourceModel
        {
          Title = Caption + " \u2013 " + title,
          Body = source
        };
    }

    public DescriptionModel CreateDescriptionModel(string description)
    {
      return new DescriptionModel
        {
          Title = Caption + " \u2013 Description",
          Text = description,
          Image = Image,
          ImageLabel = Caption
        };
    }
  }
}