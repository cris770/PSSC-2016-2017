namespace Messages

open System
//use F# because  event equality can be tested directly without the need to override the equals method, 
//thus reducing the amount of code that needs to be written.
[<Interface>]
type ICommand = interface end


[<Interface>]
type IEvent = interface end