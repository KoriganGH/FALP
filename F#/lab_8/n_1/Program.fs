open System

type IPrint = interface
    abstract member Print: unit -> unit
    end

[<AbstractClass>]
type  Figure() =
    abstract member GetArea: unit -> double
    
type Rectangle (width: double, height: double) = 
    inherit Figure()

    let mutable _width = width
    let mutable _height = height

    member this.Width
        with get() = _width
        and set(value) =  _width  <- value

    member this.Height
        with get() = _height
        and set(value) = _height <- value

    override this.GetArea() =  this.Width * this.Height 
    override this.ToString() = 
        (this.Width, this.Height, (this.GetArea()))
        |||> sprintf "Rectangle |width = %f| |height = %f| |area = %f|" 
    
    interface IPrint with
        member this.Print() =
            this.ToString()
            |> printfn "%s"
    member this.Print() = (this :> IPrint).Print()

type Square (side: double) =
    inherit Rectangle(side, side)

    let mutable _side = side
    
    override this.ToString() =
        (this.Width, this.GetArea())
        ||> sprintf "Square |side = %f| |area = %f|" 

type Circle (radius: double) =
    inherit Figure()

    let mutable _radius = radius

    member this.Radius
        with get() = _radius
        and set(value) = _radius <- value

    override this.GetArea() = this.Radius * this.Radius * Math.PI

    override this.ToString() =
        (this.Radius, this.GetArea())
        ||> sprintf "Circle |radius = %f| |area = %f|"
    
    interface IPrint with
        member this.Print() =
            this.ToString() |> printfn "%s"
    member this.Print() = (this :> IPrint).Print()

type GeometricalFigure =
    |FRectangle of double * double
    |FSquare of double
    |FCircle of double

let Area (figure: GeometricalFigure) =
    match figure with
    | FRectangle(width, height) -> width * height
    | FSquare(side) -> side * side
    | FCircle(radius) -> Math.PI * radius * radius


[<EntryPoint>]
let main argv =
    List.iter (fun (figure:IPrint) -> figure.Print())  [Rectangle(11.0, 6.5); Square(8.88); Circle(4.20)]
    Console.WriteLine()
    List.iter (fun (figure:GeometricalFigure) -> printfn "%A | %f" figure  (Area figure)) [FRectangle(11.0, 6.5); FSquare(8.88); FCircle(4.20)]
    0