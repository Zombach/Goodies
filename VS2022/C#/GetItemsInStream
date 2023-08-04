using System.Text;

string path = "путь к файлу";
string start = "началоо блока";
string end = "конец блока";

try
{
    ExpectedModel expected = new(start, end);
    using Stream stream = File.OpenRead(fileInfo.FullName);

    long index = 0;
    bool isStart = true;
    long length = stream.Length;
    List<long> indexs = new();
    while (length >= index)
    {
        int ch = stream.ReadByte();
        int expectedCh = expected.GetExpectedChar(isStart);
        if (ch == expectedCh)
        {
            stream.Position--;

            bool isEarly = true;
            byte[] expectedArray = expected.GetExpected(isStart);
            foreach (byte item in expectedArray)
            {
                if (item == stream.ReadByte()) { continue; }
                isEarly = false;
                break;
            }

            if (isEarly)
            {
                index = isStart ? index : index + expected.GetExpectedLength(false);
                isStart = !isStart;
                indexs.Add(index);
            }
            stream.Position = index + 1;
        }

        index++;
    }

    List<string> source = new();
    for (int i = 0; i < indexs.Count; i += 2)
    {
        Span<byte> bytes = new(new byte[indexs[i + 1] - indexs[i]]);
        stream.Position = indexs[i];
        int read = stream.Read(bytes);
        source.Add(Encoding.UTF8.GetString(bytes));
    }

}
catch (Exception e) { throw Log.Throw($"{e.Message}"); }

public class ExpectedModel
{
    private readonly byte[] _expectedStart;
    private readonly byte _expectedStartChar;
    private readonly int _expectedStartLength;
    private readonly byte[] _expectedEnd;
    private readonly byte _expectedEndChar;
    private readonly int _expectedEndLength;

    public ExpectedModel(string start, string end)
    {
        if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
        {
            throw Log.Instance.Throw("Не корректно заданы границы");
        }
        _expectedStart = Encoding.UTF8.GetBytes(start);
        _expectedStartChar = _expectedStart[0];
        _expectedStartLength = _expectedStart.Length;
        _expectedEnd = Encoding.UTF8.GetBytes(end);
        _expectedEndChar = _expectedEnd[0];
        _expectedEndLength = _expectedEnd.Length;
    }

    public byte[] GetExpected(bool isStart) => isStart ? _expectedStart : _expectedEnd;
    public byte GetExpectedChar(bool isStart) => isStart ? _expectedStartChar : _expectedEndChar;
    public int GetExpectedLength(bool isStart) => isStart ? _expectedStartLength : _expectedEndLength;
}
