open System
open System.Text.RegularExpressions
open System.Diagnostics
    
type PassportRF(_series,_number,_fullName,_gender,_birthdate) =
    member val Series = _series 
    member val Number = _number
    member val FullName = _fullName
    member val Gender = _gender
    member val BirthDate = _birthdate      

[<EntryPoint>]
let main argv =

    0 