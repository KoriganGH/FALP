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

    override this.GetHashCode() =
        Tuple.Create(this.Series,this.Number).GetHashCode()

     override this.Equals(pas) = 
        match pas with
        | :? PassportRF as pas -> (pas.Number) = (this.Number) && (pas.Series) = (this.Series)
        |_ -> false

    interface IComparable with 
        member this.CompareTo(obj: obj):int =
            match obj with
            | :? PassportRF as pas ->
                if this.Series = pas.Series then 
                    this.Number.CompareTo (pas.Number)
                else this.Series.CompareTo (pas.Series)
            |_->invalidArg "obj" "Cравнение невозможно"

[<EntryPoint>]
let main argv =
    let test = PassportRF("0312","123456","Александр Первый","муж","25.12.1984")
    let test2 = PassportRF("0312","123456","Александр Второй","муж","25.12.1984")
    printfn "%O" (test.Equals test2)
    printfn "%O" (test.ToString())
    0 
