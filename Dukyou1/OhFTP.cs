using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Dukyou3
{
    class OhFTP
    {
        [DllImport("shell32.dll")]  //나중에 확인후 샥제요
        public static extern int ShellExecute(int hwnd, string lpOperation, string lpFile, string lpParameters,
                                                               string lpDirectory, int nShowcmd);
        public Stream ftpStream = null;
        public FtpWebResponse response;

        private string ftpServerIP, ftpUserID, ftpPassword;
        public string FtpPassword
        {
            get { return ftpPassword; }
            set { ftpPassword = value; }
        }

        public string FtpUserID
        {
            get { return ftpUserID; }
            set { ftpUserID = value; }
        }

        public string FtpServerIP
        {
            get { return ftpServerIP; }
            set { ftpServerIP = value; }
        }

        public OhFTP() : this(string.Empty, string.Empty, string.Empty) { }

        public OhFTP(string ServerIP, string UserID, string Password)
        {
            this.ftpServerIP = ServerIP;
            this.ftpUserID = UserID;
            this.ftpPassword = Password;
        }

        //private void Chk_FTP_Directory(string path, FtpWebRequest reqFTP)
        //{
        //    try
        //    {
        //        reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
        //        using (FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse())
        //        {
        //            // Okay.   
        //        }
        //    }
        //    catch (WebException ex)
        //    {
        //        if (ex.Response != null)
        //        {
        //            FtpWebResponse response = (FtpWebResponse)ex.Response;
        //            if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
        //            {
        //                MakeDir(path);
        //            }
        //        }
        //    }  

        //}
        private void Ftp_Chk_Directory(string db_name)  //ftp폴더 존재 검사
        {
            try
            {
                string mom_folder = "";
                if (db_name.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                var request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "/" + mom_folder + "/" + db_name + "/");
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    MakeDir(db_name);
            }
        }


        private void Upload(string filename, string targetFilename, string path)
        {

            try
            {
                string mom_folder = "";
                if (path.Substring(0, 1) == "L")
                    mom_folder = "local";
                else if (path.Substring(0, 1) == "M")
                    mom_folder = "macro";
                else
                    mom_folder = "center";
                if (ftpServerIP == "localhost")
                {
                    string target_folder = AppDomain.CurrentDomain.BaseDirectory;
                    target_folder += path + "\\";
                    if (!System.IO.Directory.Exists(target_folder))
                        System.IO.Directory.CreateDirectory(target_folder);
                    File.Copy(filename, target_folder + targetFilename, true);
                }
                else
                {
                    //Ftp_Chk_Directory(path);
                    FileInfo fileInf = new FileInfo(filename);
                    FileInfo target = new FileInfo(targetFilename);
                    //string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                    FtpWebRequest reqFTP;
                    // Create FtpWebRequest object from the Uri provided
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + path + "/" + target.Name));
                    //reqFTP.UsePassive =디폴트 true 로 설정되어있음  //false; //true ; 
                    // Provide the WebPermission Credintials
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                    // By default KeepAlive is true, where the control connection is not closed
                    // after a command is executed.
                    reqFTP.KeepAlive = false;

                    // Specify the command to be executed.
                    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

                    // Specify the data transfer type.
                    reqFTP.UseBinary = true;

                    // Notify the server about the size of the uploaded file
                    reqFTP.ContentLength = fileInf.Length;

                    // directory check
                    //Chk_FTP_Directory(path, reqFTP);

                    // The buffer size is set to 2kb
                    int buffLength = 2048;
                    byte[] buff = new byte[buffLength];
                    int contentLen;

                    // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
                    FileStream fs = fileInf.OpenRead();

                    // Stream to which the file to be upload is written
                    Stream strm = reqFTP.GetRequestStream();

                    // Read from the file stream 2kb at a time
                    contentLen = fs.Read(buff, 0, buffLength);

                    // Till Stream content ends
                    while (contentLen != 0)
                    {
                        // Write Content from the file stream to the FTP Upload Stream
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }

                    // Close the file stream and the Request Stream
                    strm.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        public void DeleteFTP(string fileName, string folder)
        {
            try
            {
                string mom_folder = "";
                if (folder.Substring(0, 1) == "L")
                    mom_folder = "local";
                else if (folder.Substring(0, 1) == "M")
                    mom_folder = "macro";
                else
                    mom_folder = "center";
                if (ftpServerIP == "localhost")
                {
                    string target = AppDomain.CurrentDomain.BaseDirectory;
                    target += folder + "\\" + fileName;

                    File.Delete(target);
                }
                else
                {
                    string uri = "ftp://" + ftpServerIP + "/" + fileName;
                    FtpWebRequest reqFTP;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + folder + "/" + fileName));

                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    reqFTP.KeepAlive = false;
                    reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                    string result = String.Empty;
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    long size = response.ContentLength;
                    Stream datastream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(datastream);
                    result = sr.ReadToEnd();
                    sr.Close();
                    datastream.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete error");
            }
        }

        //private string[] GetFilesDetailList()
        //{
        //    string[] downloadFiles;
        //    try
        //    {
        //        StringBuilder result = new StringBuilder();
        //        FtpWebRequest ftp;
        //        ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
        //        ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;//ListDirectory
        //        WebResponse response = ftp.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream(),System.Text.Encoding.Default);
        //        //MessageBox.Show(reader.ReadToEnd());
        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            result.Append(line);
        //            result.Append("\n");
        //            line = reader.ReadLine();
        //        }
        //        result.Remove(result.ToString().LastIndexOf("\n"), 1);
        //        reader.Close();
        //        response.Close();
        //        downloadFiles = result.ToString().Split('\n');
        //        return downloadFiles;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        downloadFiles = null;
        //        return downloadFiles;
        //    }
        //}

        //public string[] GetFileList()
        //{
        //    string[] downloadFiles;
        //    string[] fff = new string[50];
        //    StringBuilder result = new StringBuilder();
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
        //        WebResponse response = reqFTP.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream(),System.Text.Encoding.Default);
        //       // MessageBox.Show(reader.ReadToEnd());
        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            result.Append(line);
        //            result.Append("\n");
        //            line = reader.ReadLine();
        //        }
        //        result.Remove(result.ToString().LastIndexOf('\n'), 1);
        //        reader.Close();
        //        response.Close();
        //        return result.ToString().Split('\n');
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message);
        //        downloadFiles = null;
        //        return downloadFiles;
        //    }
        //}
        //private void Download(string filePath, string fileName)
        //{
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        //filePath = <<The full path where the file is to be created.>>, 
        //        //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
        //        FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileName));
        //        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();
        //        int cl = Convert.ToInt32(response.ContentLength);
        //        int bufferSize = cl;
        //        int readCount;
        //        byte[] buffer = new byte[bufferSize];

        //        readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        while (readCount > 0)
        //        {
        //            outputStream.Write(buffer, 0, readCount);
        //            readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        }

        //        ftpStream.Close();
        //        outputStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void Download(string filePath, string fileName, string path)
        {
            FtpWebRequest reqFTP;
            try
            {
                string mom_folder = "";
                if (path.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                if (ftpServerIP == "localhost")
                {
                    string target = AppDomain.CurrentDomain.BaseDirectory;
                    target += path + "\\" + fileName;

                    File.Copy(target, @"c:\temp", true);
                }
                else
                {
                    //filePath = <<The full path where the file is to be created.>>, 
                    //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                    FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + path + "/" + fileName));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    int cl = Convert.ToInt32(response.ContentLength);
                    int bufferSize = cl;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }

                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Download1(string filePath, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                string mom_folder = "";
                if (fileName.Substring(0, 1) == "L")
                    mom_folder = "local";
                else if (fileName.Substring(0, 1) == "M")
                    mom_folder = "macro";
                else
                    mom_folder = "center";
                if (ftpServerIP == "localhost")
                {
                    string target = AppDomain.CurrentDomain.BaseDirectory;
                    target += fileName;

                    File.Copy(target, filePath, true);
                }
                else
                {
                    //filePath = <<The full path where the file is to be created.>>, 
                    //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                    FileStream outputStream = new FileStream(filePath, FileMode.Create);

                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + fileName));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    Stream ftpStream = response.GetResponseStream();
                    int cl = Convert.ToInt32(response.ContentLength);
                    int bufferSize = cl;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }

                    ftpStream.Close();
                    outputStream.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Viewload(string fileName, string folder)  //나중에 검토후 삭제요
        {
            FtpWebRequest reqFTP;
            try
            {
                string mom_folder = "";
                if (folder.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                //filePath = <<The full path where the file is to be created.>>, 
                //fileName = <<Name of the file to be created(Need not be the name of the file on FTP server).>>
                FileStream outputStream = new FileStream(@"c:\temp" + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + folder + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                int cl = Convert.ToInt32(response.ContentLength);
                int bufferSize = cl;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ShellExecute(0, String.Empty, outputStream.Name, String.Empty, String.Empty, 1);

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private long GetFileSize(string filename, string folder)
        {
            FtpWebRequest reqFTP;
            long fileSize = 0;
            try
            {
                string mom_folder = "";
                if (folder.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + folder + "/" + filename));
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                fileSize = response.ContentLength;

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return fileSize;
        }

        public void Rename(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"+ currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MakeDir(string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                string mom_folder = "";
                if (dirName.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                // dirName = name of the directory to create.
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + dirName));
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpLoadFile(string fn, string tn, string pn)
        {
            Upload(fn, tn, pn);
        }

        public void DownLoadFile(string path, string fn, string server_folder)
        {
            Download(path, fn, server_folder);
        }

        public void DownLoadFile1(string path, string fn)
        {
            Download1(path, fn);
        }

        public void ViewLoadFile(string fn, string folder)
        {
            Viewload( fn, folder );
        }

        public void DeleteFile(string fn, string server_folder)
        {
            DeleteFTP(fn, server_folder);
        }

        public Stream Download_stream(string fileName, string path)
        {
            FtpWebRequest reqFTP;
            try
            {
                string mom_folder = "";
                if (path.Substring(0, 1) == "L")
                    mom_folder = "local";
                else
                    mom_folder = "center";
                if (ftpServerIP == "localhost")
                {
                    string target = AppDomain.CurrentDomain.BaseDirectory;
                    target += path + "\\" + fileName;

                    File.Copy(target, @"c:\temp", true);
                }
                else
                {
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + mom_folder + "/" + path + "/" + fileName));
                    reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                    response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ftpStream;
        }        
    }
}
