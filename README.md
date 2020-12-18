# RadioBrowser

Radio API wrapper for [radio-browser.info](https://radio-browser.info).

Compatible with .NET 5 and .NET Standard 2.1.

## How to use
* [Nuget package](https://www.nuget.org/packages/RadioBrowser)
* [Example project](RadioBrowser.Example)
* [Radio Browser official docs](https://nl1.api.radio-browser.info/)

### Samples

#### Simple search
```c#
var radioBrowser = new RadioBrowserClient();
var results = await radioBrowser.Search.ByNameAsync("station name");
Console.WriteLine(results.First().Name);
```

#### Advanced search
To use advanced search use `AdvancedSearchOptions`

```c#
var results = await radioBrowser.Search.AdvancedAsync(new AdvancedSearchOptions
    {
        Language = "english",
        TagList = "news"
    });
```

#### Lists

```c#
// Without limits
var results = await radioBrowser.Stations.GetByVotesAsync();
```

```c#
// With limit
var results = await radioBrowser.Stations.GetByVotesAsync(10);
```

```c#
// With filter
var results = await radioBrowser.Lists.GetTagsAsync("funk");
```
