// See https://aka.ms/new-console-template for more information
using ProcessData;

var lstFootballRecords = new List<FootballRecord>();
var lstWeatherRecords = new List<Temprature>();

int counter = 0;
int starting;
string output,fileName = "";


Console.WriteLine("Select Data Type: \n 0 for football \n 1 for weather");
int datType = Convert.ToInt32(Console.ReadLine());


if (datType != 0 && datType != 1)
{
	Console.WriteLine("Invalid data type.");
	return;
}
else if (datType == 0)
{
	starting = 2;
	fileName = "football.dat";
}
else
{
	starting = 3;
	fileName = "weather.dat";
}


var sr = new StreamReader(fileName);


while (!sr.EndOfStream)
{
	string s = sr.ReadLine();
	counter++;
	if (counter < starting)
		continue;


	if (!String.IsNullOrEmpty(s.Trim()))
	{
		try
		{
			if (datType == 0)
				lstFootballRecords.Add(new FootballRecord(s));
			else
				lstWeatherRecords.Add(new Temprature(s));

		}
		catch (Exception ex)
		{

		}
	}

}
sr.Close();

if (datType == 0)
{
	FootballRecord objSmallestDiffernce = new FootballRecord();
	double difference = Double.MaxValue;
	foreach (var fbRecord in lstFootballRecords)
	{
		int dif1 = fbRecord.For - fbRecord.Against;
		int dif2 = fbRecord.Against - fbRecord.For;
		if (dif1 > -1 && dif1 <= dif2 && dif1 < difference)
		{
			difference = dif1;
			objSmallestDiffernce = fbRecord;
		}
		else if (dif2 > -1 && dif2 < difference)
		{
			difference = dif2;
			objSmallestDiffernce = fbRecord;
		}
	}
	output = objSmallestDiffernce.Team;
}
else
{
	Temprature objSmallestSpread = new Temprature();
	double smallestTemp = Double.MaxValue;
	for (int i = 0; i < lstWeatherRecords.Count; i++)
	{
		if (i > 0)
		{
			Temprature today = lstWeatherRecords[i];
			Temprature yesterday = lstWeatherRecords[i - 1];
			double change = today.MnT - yesterday.MnT;
			if (change > 0 && smallestTemp > change)
			{
				smallestTemp = change;
				objSmallestSpread = today;
			}
		}
	}
	output = objSmallestSpread.Dy.ToString();
}

Console.WriteLine(output);


