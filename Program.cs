int a = 3;
int b = 5;
int c = 40;
int d = c-- - b * a;    // a=3  b=5  c=39  d=25
Console.WriteLine($"a={a}  b={b}  c={c}  d={d}");

void SayHello()
{
    Console.WriteLine("Hello");
}

SayHello(); // Hello
SayHello(); // Hello