using IronCompress;
using Parquet;

namespace Speckle.Sdk.Pipelines.Send.Artifacts;

/// <summary>
/// Compression codec of the bundle parquet files: <c>Zstd</c> when the IronCompress native library is available,
/// otherwise <c>Snappy</c>, which is fully managed. The packages do not ship that native library, so on .NET Framework
/// Zstd has no codec, and the managed Zstd fallback writes corrupt data in 32-bit processes.
/// </summary>
internal static class ParquetCompression
{
  public static CompressionMethod Method { get; } =
    Iron.IsNativeLibraryAvailable ? CompressionMethod.Zstd : CompressionMethod.Snappy;
}
