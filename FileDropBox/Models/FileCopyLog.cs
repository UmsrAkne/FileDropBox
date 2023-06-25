using System;
using System.Collections.Generic;

namespace FileDropBox.Models
{
    public class FileCopyLog
    {
        /// <summary>
        /// コピーの対象となったファイルのパス、またはディレクトリのパス
        /// </summary>
        public string TargetFilePath { get; set; } = string.Empty;

        /// <summary>
        /// コピー先のパス
        /// </summary>
        public string DestinationPath { get; set; } = string.Empty;

        /// <summary>
        /// このログを生成した際にコピーしたファイル、ディレクトリのリスト
        /// コピーしたのがファイルの場合は、そのファイル名のみが入る。
        /// ディレクトリだった場合、コピーした全ファイル名、ディレクトリ名が入る。
        /// </summary>
        public List<string> CurrentFilePaths { get; set; } = new();

        /// <summary>
        /// このログを生成した日時
        /// </summary>
        public DateTime DateTIme { get; set; } = DateTime.Now;
    }
}