const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

string spanText = "<span>";
string endSpanText = @"</span>";

string divText = "<div>";
string endDivText = @"</div>";

int quantityStart = input.IndexOf(spanText);
quantityStart += spanText.Length;
int quantityEnd = input.IndexOf(endSpanText);

int outputStart = input.IndexOf(divText);
outputStart += divText.Length;
int outputEnd = input.IndexOf(endDivText);

quantity = input.Substring(quantityStart, (quantityEnd-quantityStart));

output = input.Substring(outputStart, (outputEnd - outputStart)).Replace("&trade", "&reg");

Console.WriteLine(quantity);
Console.WriteLine(output);