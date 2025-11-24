type Matrix(rows: int, cols: int) =
    let data = Array2D.zeroCreate<double> rows cols

    member this.Rows = rows
    member this.Cols = cols

    member this.Item
        with get (r, c) = data.[r, c]
        and set (r, c) value = data.[r, c] <- value

    override this.ToString() : string =
        let constant =
            [ 0 .. rows - 1 ]
            |> List.map (fun r ->
                [ 0 .. cols - 1 ]
                |> List.map (fun c -> sprintf "%6.2f" data.[r, c])
                |> String.concat " ")
            |> String.concat "\n"

        sprintf "Matrix (%d x %d):\n%s" rows cols constant

    static member (+)(m1: Matrix, m2: Matrix) =
        if m1.Cols <> m2.Cols || m1.Rows <> m2.Cols then
            failwith "行列のサイズが異なるため足し算を実行できません"

        let result = Matrix(m1.Rows, m1.Cols)

        for r = 0 to m1.Rows - 1 do
            for c = 0 to m1.Cols - 1 do
                result.[r, c] <- m1.[r, c] + m2.[r, c]

        result

    static member (*)(m1: Matrix, k: float) =
        let result = Matrix(m1.Rows, m1.Cols)

        for r = 0 to m1.Rows - 1 do
            for c = 0 to m1.Cols - 1 do
                result.[r, c] <- k * m1.[r, c]

        result

    static member (*)(m1: Matrix, m2: Matrix) =
        if m1.Cols <> m2.Rows then
            failwith "行列のサイズが適切でないため掛け算できません"

        let result = Matrix(m1.Rows, m2.Cols)

        for r = 0 to result.Rows - 1 do
            for c = 0 to result.Cols - 1 do
                for k = 0 to m1.Cols - 1 do
                    result.[r, c] <- result.[r, c] + (m1.[r, k] * m2.[k, c])

        result

let x = new Matrix(2, 3)
x.[0, 0] <- 1
x.[0, 1] <- 2
x.[0, 2] <- 3
x.[1, 0] <- 1
x.[1, 1] <- 2
x.[1, 2] <- 3

let y = new Matrix(3, 1)
y.[0, 0] <- 1
y.[1, 0] <- 2
y.[2, 0] <- 3

(x * y).ToString() |> printfn "%s"
