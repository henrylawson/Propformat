# Introduction
Propformat is a simple class that wraps around string.Format and lets you conveniently stringify
entities through their properties. Use it when you want to string format the same model in lots
of places but you dont want to couple it to the model itself and perhaps you have different
representations that you want to define.

# Usage
Using Propformat is super easy. Just copy the class from `Propformat/PorpertyFormatter.cs` 
and enjoy!

## Examples

```c#
var formatter = new PropertyFormatter<Person>(
	"Hello {0}, You are {1} this year!",
	x => x.Name,
	x => x.Age.ToString(CultureInfo.InvariantCulture)
);

Console.WriteLine(formatter.Format(defaultPerson));

// Outputs: Hello Henry, You are 23 this year!
```

```c#
var htmlFormatter = new PropertyFormatter<Person>(
	"<div class=\"name\">{0}</div><div class=\"age\">{1}</div>",
	x => x.Name, 
	x => x.Age.ToString(CultureInfo.InvariantCulture)
);

Console.WriteLine(formatter.Format(defaultPerson));

// Outputs: <div class=\"name\">Henry</div><div class=\"age\">23</div>
```