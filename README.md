# HueController
a .Net API for controlling Philips Hue

## Register your Application

```cs
    var hue = new HueAPI();
    var user = await hue.Configuration.CreateUserAsync(new CreateUserRequest { DeviceType = "my_hue_Application#Computer1" });

    var userName = user["success"].UserName;
    //Save the above UserName for later user
```

## Control a Group of Lights 
In the following example we are going to Turn on all of the lights in the Study over 1 second with full brightness

```cs
    //User the Username that was returned from the Register Application
    var hue = new HueAPI(_userName);

    //Get a list of all Groups
    var groups = await hue.Groups.GetAllGroupsAsync();

    //Find a the group named Study
    var studyId = groups.Where(g => g.Value.Name == "Study").Select(g => g.Key).First();

    var builder = new GroupStateBuilder(studyId);
    await builder.TurnOn()
                .WithBrightness(254)
                .WithTransitionTime(10)
                .SendAsync(hueController);
```