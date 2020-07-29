# VMNotification

**VMNotification** is a solution to improve the notifications handling. We have two kinds of messages:

  - **Errors**
  - **Notifications**

Add in Startup.cs file, the follow dependency injection:
```sh
 services.AddScoped<Notificator>();
```

### Examples

```sh

[Route("[controller]")]
public class TestController : Controller
    
    private readonly Notificator _notificator;
    private readonly TestService _service;

    public TestController(Notificator notificator, TestService service) {
        _notificator = notificator;
        _service = service;
    }
    
    [HttpPost]
    public void Post(Customer customer){
    
       _service.AddCustomer(customer);
       
       if(_notificator.IsValid){
           return Ok(new 
           {
               notifications: _notificator.GetNotifications();
           });
       }
       
       return BadRequest(new 
       {
          errors: _notificator.GetErrors();
       });
    }
}


public TestService {
    
    private readonly Notificator _notificator;

    public TestService(Notificator notificator) {
        _notificator = notificator;
    }
    
    public void AddCustomer(Customer customer){
    
        //this action add a new error in the list
        if(string.IsNullOrEmpty(customer.Name)
            _notificator.AddError("Name is invalid");
        
        //this action add a new notification in the list
        _notificator.AddNotification("The confirmation link was sent to the email.!");
    }
}

```
**Add Errors from FluentValidation:**
```sh
 Customer customer = new Customer();
 CustomerValidator validator = new CustomerValidator();

 _notificator.AddErrors(validator.Validate(customer));
```

**To get all errors:**
```sh
 _notificator.GetErrors();
```

**To get all notifications:**
```sh
 _notificator.GetNotifications();
```

**To remove all errors:**
```sh
 _notificator.ClearErrors();
```

**To remove all notifications:**
```sh
 _notificator.ClearNotifications();
```



