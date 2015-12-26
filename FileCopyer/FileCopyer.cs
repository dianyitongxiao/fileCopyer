using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileCopyer
{
    public class FileCopyer
    {
        public string SourcePath { get; set; }
        public string DestPath { get; set; }
        public IOutput OutPuter { get; set; }

        private List<string> ignoreFiles { get; set; }

        public FileCopyer()
        {
            ignoreFiles = new List<string>();
        }

        public void AddIgnoreFile(string file)
        {
            ignoreFiles.Add(file);
        }

        public void Start()
        {
            if (OutPuter == null) OutPuter = new DefaultOutputer();

            OutPuter.Write("参数验证中");

            if (string.IsNullOrEmpty(SourcePath))
                throw new Exception("SourcePath为空");
            if (string.IsNullOrEmpty(DestPath))
                throw new Exception("DestPath为空");

            if (!Directory.Exists(DestPath))
            {
                OutPuter.Write($"创建目标目录{DestPath}");
                Directory.CreateDirectory(DestPath);
            }

            OutPuter.Write("开始复制文件");
            MoveFiles(this.SourcePath);
        }

        private void MoveFiles(string directory)
        {
            var files = Directory.GetFiles(directory);

            var destFile = "";
            var destDir = "";

            files.ToList().ForEach(m =>
            {
                destFile = m.Replace(this.SourcePath, this.DestPath);
                destDir = Path.GetDirectoryName(destFile);

                if (!Directory.Exists(destDir))
                {
                    OutPuter.Write($"创建目标目录{DestPath}");
                    Directory.CreateDirectory(destDir);
                }

                if (!ignoreFiles.Contains(Path.GetFileName(m)))
                {
                    OutPuter.Write($"复制文件{m}");
                    File.Copy(m, destFile, true);
                }
            });

            var directories = Directory.GetDirectories(directory);
            directories.ToList().ForEach(m =>
            {
                MoveFiles(m);
            });
        }
    }
}
