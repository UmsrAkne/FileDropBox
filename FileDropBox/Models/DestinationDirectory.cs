using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace FileDropBox.Models
{
    public class DestinationDirectory
    {
        public string DestPath { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Exists => Directory.Exists(DestPath);

        /// <summary>
        /// 引数に入力したパスが示すファイル、またはディレクトリを、このオブジェクトの DestPath の中にコピーします。
        /// </summary>
        /// <param name="targetFilePath">ファイル、ディレクトリのパス</param>
        public void Copy([NotNull]string targetFilePath)
        {
            // 対象のパスのファイル、またはディレクトリがあるか確認する。
            var existsFile = File.Exists(targetFilePath) || Directory.Exists(targetFilePath);
            if (string.IsNullOrWhiteSpace(targetFilePath) || !existsFile)
            {
                return;
            }

            // ディレクトリの場合は直接 System.IO でのコピーが不可であるため、確認して処理を分岐させる。
            var targetIsDirectory = Directory.Exists(targetFilePath);
            var fileName = Path.GetFileName(targetFilePath);
            var dest = $@"{DestPath}\{fileName}";

            if (targetIsDirectory)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(
                    targetFilePath,
                    dest,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            else
            {
                File.Copy(targetFilePath, dest);
            }
        }
    }
}