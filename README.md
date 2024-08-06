# BTSID

BTSID is a .NET library that generates unique and short Base36 encoded IDs. This library is useful for creating short IDs for databases, URLs, and other applications where a compact identifier is needed.

## Features

- Convert integers, long, and DateTime to Base36 encoded strings
- Generate unique Base36 encoded IDs based on different modes
- Convert Base36 encoded strings back to decimal
- Get the next Base36 encoded number in sequence

## Installation

Install the package via NuGet Package Manager:

```shell
dotnet add package BTSID
```

## Usage

### Convert Numbers to Base36

```csharp
using BTSID;

string base36 = 12345.ToBase36(); // "9ix"
string dateBase36 = DateTime.Now.ToBase36(); // Based on current DateTime
```

### Generate Unique Base36 IDs

```csharp
using BTSID;

string uniqueId = BTSID.NewBase36Number(NumberMode.Uniq);
string shortId = BTSID.NewBase36Number(NumberMode.Short);
string compressedId = BTSID.NewBase36Number(NumberMode.Compressed);
```

### Convert Base36 to Decimal

```csharp
using BTSID;

decimal decimalValue = BTSID.ToDecimal("9ix"); // 12345
```

### Get Next Base36 Number

```csharp
using BTSID;

string nextNumber = BTSID.GetNextNumber("9ix"); // "9iy"
```

## Documentation

### Methods

- `ToBase36(this string number)`: Converts a string representation of a number to Base36.
- `ToBase36(this long number)`: Converts a long number to Base36.
- `ToBase36(this int number)`: Converts an integer to Base36.
- `ToBase36(this DateTime dateTime)`: Converts a DateTime to Base36.
- `NewBase36Number(NumberMode mode)`: Generates a new Base36 number based on the specified mode.
- `GetNextNumber(string currentNumber)`: Gets the next Base36 number in sequence.
- `ToDecimal(string base36Number)`: Converts a Base36 number to decimal.

### Enum

- `NumberMode`
  - `Uniq`: Generates a unique Base36 number based on DateTime and process ID.
  - `Short`: Generates a Base36 number based on DateTime with milliseconds.
  - `Compressed`: Generates a Base36 number based on DateTime without milliseconds.

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.
