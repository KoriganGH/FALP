open System

let task1 str = 
    let res1 = String.length(String.filter (fun x -> x>='А' && x<='я') str)
    Console.WriteLine(res1)

let task2 str =
    let flip = Seq.rev str
    Seq.forall2 (fun x y -> x=y) str flip

let date (str:string)= 
    let day = str.Remove(2,8)
    let month = str.Remove(0,3).Remove(2,5)
    let year = str.Remove(0,6)
    day<="31"&&day>="01" && month>="01"&& month<="12" && year >"0000" && year<"9999"

let task3 (str:string) = 
    let rec finddate (stroka:string) (strNow: string) (strResult: string) = 
        match stroka with
        |"" -> strResult
        |_-> 
            let newStr = 
                if strNow.Length<10 then
                    strNow + stroka.Remove(1,stroka.Length-1)
                else strNow.Remove(0,1)+(stroka.Remove(1,stroka.Length-1))
            let newResult = 
                if (newStr.Length = 10 && date newStr) then strResult+"\n"+newStr
                else strResult
            finddate (stroka.Remove(0,1)) newStr newResult
    if finddate str "" "" = "" 
    then "date not exist" |> ignore
    else finddate str "" "" |> ignore
    Console.WriteLine("date:{0}",finddate str "" "")

let f n str  = 
    match n with 
    |1 -> Convert.ToString(task1 str)
    |2 -> Convert.ToString(task2 str)
    |3 -> Convert.ToString(task3 str)
    
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку: ")
    let str = Console.ReadLine()
    Console.WriteLine("Введите номер задания: ")
    let n = Console.ReadLine() |> Convert.ToInt32
    f n str |> ignore 
    if n = 2 && str |> task2 
    then Console.WriteLine("there is a palindrome") 
    else Console.WriteLine("no palindrome")
    0
