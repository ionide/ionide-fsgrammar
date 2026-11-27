module InterpolatedStrings

let name = "World"
let count = 3
let price = 9.99
let today = System.DateTime(2026, 11, 27)

let plain = $"Hello, {name}!"
let escapedBraces = $"{{literal}} and {count}"
let formatted = $"{price:N2} on {today:yyyyMMdd}"
let typed = $"%d{count} items, tab\t{name}"
let verbatim = $@"C:\Users\{name}\file ""quoted"""
let verbatimOtherOrder = @$"{name}\n stays literal"
let path = $"{name}\{count}.txt"
let cast = $"{count :> obj} {box name :?> string}"
let triple = $"""He said "hi" to {name}"""
let json = $$"""{"name": "{{name}}", "count": {{count}}}"""
let tripleDollar = $$$"""{{literal}} {{{count}}}"""
let nested = $"""{ if count > 1 then "many" else "one" }"""
let braces = $"{ {| A = 1 |}.A } and { [ for i in 1 .. count -> i ] }"
let multiLine = $"""
    Name: {name}
    Count: {count}
    """
let after = 42
