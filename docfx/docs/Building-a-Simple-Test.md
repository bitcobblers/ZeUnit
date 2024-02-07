Now that you are set up to run test in your application and you have executed [Your First Test](Your-First-Test), lets get into the tests how testing works and tackle the elephant in the room.  

> WHERE IS MY ASSERT !?!?!?!?!?!?!

Its gone.  And so is the code stench of static global objects....  But lets take it down a notch.

Much of the design approach of ZeUnit tries to bring in lessons learned from functional program to Unit testing.  Trying to align unit testing with function programing really does mean that we have to tackle the basis of unit testing which sits on top of a public static that causes spooky action at a distance.  As a result some variation of **ZeResult** needs be returned from a method for the ZeUnit test discovery to pick up on the test.  A nice side effect is that we no longer need to tag the releases with **[Fact]** or **[TestMethod]**.  

Supported test return types
* ZeResult - single instance of one or more assertions.
* IEnumerable\<ZeResult\> -  return 0 or more **ZeResult**s
* Task\<ZeResult\> - enabling a single **ZeResult** to be returned from a function with *async*
* IObservable\<ZeResult\> - any number of results at some point in time.

