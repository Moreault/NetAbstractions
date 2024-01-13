![NetAbstractions](https://github.com/Moreault/NetAbstractions/blob/master/netabstractions.png)

# NetAbstractions
Abstractions for .NET base types such as File and Directory to provide easier means to mock low-level operations.

For some strange and obscure reason, Microsoft thought it was a good idea to have unmockable static classes for most low-level operations such as deleting files and folders. 
Suppose you want to test a method that checks whether a file exists and delete it if it does? You could create temporary files to be used with your tests. It could work but it would also needlessly complexify your tests’ logic. 
You might also be tempted to just not test that method. It’s fine if you don’t care about code quality. It’s okay, I’m not judging (I am.)

Using this library, you can do the following: 

```c#
public class ShadyService : IShadyService
{
	private readonly IFile _file;

	public ShadyService(IFile file)
	{
		_file = file;
	}

	public void DoTheThing(string path)
	{
		if (_file.Exists(path))
			_file.Delete(path);
	}
}
```

And down the line,

```c#
[TestClass]
public class ShadyServiceTest
{
	[TestMethod]
	public void SomeTest()
	{
		var file = new Mock<IFile>();
		var shadyService = new ShadyService(file.Object);

		var path = "c:/temp/something.wat";
		shadyService.DoTheThing(path);

		file.Setup(x => x.Exists(path)).Returns(true);

		file.Verify(x => x.Delete(path), Times.Once);
	}
}
```

## Getting started

### Using (https://github.com/Moreault/AutoInject "AutoInject")

```c#
public void ConfigureServices(IServiceCollection services)
{
	//This only needs to be called once for your entire application
    services.AddAutoInjectServices();
}
```

### Manually

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddNetAbstractions();
}
```

You can also add every service one by one if you're into that but the end result will be the same.

## IInstanceWrapper and the Unwrapped property

This can be a bit confusing at first. Why would you expose an unwrapped property on a wrapped type?

Well because sometimes that's what you need to do if you make your own wrappers or when using 3rd party code.

In short, you should never use the Unwrapped property outside of wrapper code.

This mechanism may be changed in the future but it is so far the least painful way to deal with wrapping issues.