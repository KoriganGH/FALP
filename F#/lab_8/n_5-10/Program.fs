open System
open System.Text.RegularExpressions
open System.Diagnostics
 
let regSeries (str:string) =
    let r = @"^([0-9]{2}[0-9]{2})?$"
    Regex.IsMatch(str,r)

let regNumber (str:string) =
    let r = @"^([0-9]{6})?$"
    Regex.IsMatch(str,r)

let regBirthDate (str:string) =
    let r = @"^(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](19|20)\d\d$"
    Regex.IsMatch(str,r)

let regFullName (str:string) =
    let r = @"^([А-ЯA-Z]|[А-ЯA-Z][\x27а-яa-z]{1,}|[А-ЯA-Z][\x27а-яa-z]{1,}\-([А-ЯA-Z][\x27а-яa-z]{1,}|(оглы)|(кызы)))\040[А-ЯA-Z][\x27а-яa-z]{1,}(\040[А-ЯA-Z][\x27а-яa-z]{1,})?$"
    Regex.IsMatch(str,r)

let regGender(str:string) =
    let r = "(^Муж$)|(^муж$)|(^Жен$)|(^жен$)|(^Мужской$)|(^мужской$)|(^Женский$)|(^женский$)|(^М$)|(^м$)|(^Ж$)|(^ж$)"
    Regex.IsMatch(str,r)

type PassportRF(_series,_number,_fullName,_gender,_birthdate) =
    member val Series = 
        if regSeries _series then _series
        else
            let rec prom str t_f =
                match str,t_f with
                |other,true -> other
                |other,false ->
                    Console.Clear()
                    Console.WriteLine("Неверный формат серии паспорта! Введите корректный вариант:")
                    let s = Console.ReadLine()
                    let new_t_f = if regSeries s then true else false
                    prom s new_t_f
            prom "" false 
            
    member val Number = 
        if regNumber _number then _number
        else
            let rec prom str t_f =
                match str,t_f with
                |other,true -> other
                |other,false ->
                    Console.Clear()
                    Console.WriteLine("Неверный формат номера паспорта! Введите корректный вариант:")
                    let s = Console.ReadLine()
                    let new_t_f = if regNumber s then true else false
                    prom s new_t_f
            prom "" false  

    member val FullName = 
        if regFullName _fullName then _fullName
        else
            let rec prom str t_f =
                match str,t_f with
                |other,true -> other
                |other,false ->
                    Console.Clear()
                    Console.WriteLine("Неверный формат ФИО! Введите корректный вариант:")
                    let s = Console.ReadLine()
                    let new_t_f = if regFullName s then true else false
                    prom s new_t_f
            prom "" false  
       
    member val Gender =
        if regGender _gender then _gender
        else
            let rec prom str t_f =
                match str,t_f with
                |other,true -> other
                |other,false ->
                    Console.Clear()
                    Console.WriteLine("Неверный формат пола! Введите корректный вариант:")
                    let s = Console.ReadLine()
                    let new_t_f = if regGender s then true else false
                    prom s new_t_f
            prom "" false  
       
    member val BirthDate =
        if regBirthDate _birthdate then _birthdate
        else 
            let rec prom str t_f =
                match str,t_f with
                |other,true -> other
                |other,false ->
                    Console.Clear()
                    Console.WriteLine("Неверный формат даты рождения! Введите корректный вариант:")
                    let s = Console.ReadLine()
                    let new_t_f = if regBirthDate s then true else false
                    prom s new_t_f
            prom "" false  

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


[<AbstractClass>]
type GenDoc() =
   abstract member searchDoc : PassportRF -> bool

type ArrayDoc(list:PassportRF list) =
    inherit GenDoc()
    member val Arr = Array.ofList list
    override this.searchDoc(now) =
        Array.exists(fun k -> k.Equals now) this.Arr

type ListDoc(list:PassportRF list) =
    inherit GenDoc()
    member val L = list
    override this.searchDoc(now) =
        List.exists(fun k -> k.Equals now) this.L

type SetDoc(list:PassportRF list) =
    inherit GenDoc()
    member val S = Set.ofList list
    override this.searchDoc(now) =
        Set.exists(fun k -> k.Equals now) this.S

type BinListDoc(list: PassportRF list)=
    inherit GenDoc()
    let rec binSearch (sortedL: PassportRF list) (curr: PassportRF) =
        match List.length sortedL with
        | 0 -> false
        | len ->
            let mid = len/2
            match compare curr sortedL.[mid] with
            | 0 -> true
            | 1->binSearch sortedL.[mid+1..] curr
            | _->binSearch sortedL.[..mid-1] curr
    member this.BinList = List.sortBy (fun (x:PassportRF) -> (x.Series, x.Number)) list 
    override this.searchDoc(now) =
        binSearch this.BinList now

[<EntryPoint>]
let main argv =
    let test = PassportRF("0312","123456","Александр Первый","муж","25.12.1984")
    let test2 = PassportRF("0312","123456","Александр Второй","муж","25.12.1984")
    printfn "%O" (test.Equals test2)
    printfn "%O" (test.ToString())
    0 
