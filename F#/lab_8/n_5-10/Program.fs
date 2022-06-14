open System
open System.Text.RegularExpressions
open System.Diagnostics
 
type PassportRF(_series,_number,_fullName,_gender,_birthdate) =
    member val Series = _series 
    member val Number = _number
    member val FullName = _fullName
    member val Gender = _gender
    member val BirthDate = _birthdate      

    override this.ToString() = 
        sprintf "Series: %s | Number: %s | FullName: %s | Gender: %s | BirthDate: %s" this.Series this.Number this.FullName this.Gender this.BirthDate

[<EntryPoint>]
let main argv =
    let test = PassportRF("0312","123456","Александр Первый","муж","25.12.1984")
    printfn "%O" (test.ToString())
    0 
