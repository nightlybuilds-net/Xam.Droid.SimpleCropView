# Xamarin Android binding library for SimpleCropView

This is a Xamarin.Android binding library for SimpleCropView.   
Package is available on NuGet: [Xam.Droid.SimpleCropView](https://www.nuget.org/packages/Xam.Droid.SimpleCropView)

Please see [original SimpleCropView on GitHub](https://github.com/IsseiAoki/SimpleCropView) for documentation.


## CallBacks
Those callbacks are used by SimpleCropView:

 - ICallBack
 - ICropCallback
 - ILoadCallback
 - ISaveCallback

The binding library expose a class for every callback interface, here an example of how create a callback object:

	var myCallBack = new CallBack().OnErrorDo(()=>{Console.WriteLine("oh no!").OnSuccessDo(obj=>{Console.WriteLine("yeah!")})})


##Note about versioning##
Master branch contains the last published version on Nuget and has every previous version tagged.
The version is based on SimpleCropView version:

 - First three number are SimpleCropView version.
 - Fourth number is for binding library revision.

 Have fun!

##Follow Me

 - Twitter: [@markjackmilian](https://twitter.com/markjackmilian)
 - MyBlog: [markjackmilian.net](http://markjackmilian.net/blog)
 - Linkedin: [linkedin](https://www.linkedin.com/in/marco-giacomo-milani)