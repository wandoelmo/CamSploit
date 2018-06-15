﻿using System;
using ExploitMaker;

namespace CamSploit
{
    public class Writter : IDisposable
    {
        private TxtFile _txtFile;

        public Writter(string outputPath)
        {
            Init(outputPath);
        }

        public void Dispose()
        {
            _txtFile.Dispose();
        }

        public void InitTest(string cve, Camera cam)
        {
            Console.WriteLine("Testing {0} for Cam {1}", cve, cam.Address);
        }

        public void TestFailed(string cve, Camera cam)
        {
            Console.WriteLine("The Cam {0} is not vulnerable or it is not available for the {1}", cam.Address, cve);
            if (_txtFile != null)
                _txtFile.Write(cam + ",,," + cve);
        }

        public void TestSuccess(string cve, Camera cam, Credencial cred)
        {
            Console.WriteLine("The Cam {0} is vulnerbale to {1} the result is {2}", cam.Address, cve, cred);
            if (_txtFile != null)
                _txtFile.Write(cam + "," + cred.Username + "," + cred.Password + "," + cve);
        }

        private void Init(string output)
        {
            _txtFile = new TxtFile(output);
            _txtFile.Create();
        }
    }
}