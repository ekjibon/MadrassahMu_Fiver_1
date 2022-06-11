using CoreWeb.Business.Common;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using Subscription.Business.Dto;
using Subscription.Business.ReturnType;


//using iTextSharp.text;
//using iTextSharp.text.pdf;

//using Subscription.Business.Dto;
//using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public partial class PdfService : BaseService
    {
        public BusinessResponse<CombinePdfFileListReturnType> CombinePdfFileList(CombinePdfFileListDto combinePdfFileListDto)
        {
            BusinessResponse<CombinePdfFileListReturnType> response = new BusinessResponse<CombinePdfFileListReturnType>();

            try
            {
                response.Result = CombinePdfFileListRaw(combinePdfFileListDto);

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal CombinePdfFileListReturnType CombinePdfFileListRaw(CombinePdfFileListDto combinePdfFileListDto)
        {
            CombinePdfFileListReturnType combinePdfFileListReturnType = new CombinePdfFileListReturnType();

            string outputFilePath = combinePdfFileListDto.OutputFilePath;


            using (PdfDocument targetDoc = new PdfDocument())
            {
                foreach (string pdf in combinePdfFileListDto.FilePaths)
                {
                    using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                targetDoc.Save(outputFilePath);
            }


            //List<PdfReader> readerList = new List<PdfReader>();
            //foreach (string filePath in combinePdfFileListDto.FilePaths)
            //{
            //    PdfReader pdfReader = new PdfReader(filePath);
            //    readerList.Add(pdfReader);
            //}

            //Document document = new Document(PageSize.A4, 0, 0, 0, 0);
            ////Create blank output pdf file and get the stream to write on it.
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFilePath, FileMode.Create));
            //document.Open();

            //foreach (PdfReader reader in readerList)
            //{
            //    for (int i = 1; i <= reader.NumberOfPages; i++)
            //    {
            //        PdfImportedPage page = writer.GetImportedPage(reader, i);
            //        document.Add(iTextSharp.text.Image.GetInstance(page));
            //    }
            //}
            //document.Close();


            //using (FileStream stream = new FileStream(outputFilePath, FileMode.Create))
            //{
            //    Document document = new Document();
            //    iTextSharp.text.pdf.PdfCopy pdf = new iTextSharp.text.pdf.PdfCopy(document, stream);
            //    PdfReader reader = null;
            //    try
            //    {
            //        document.Open();
            //        foreach (string file in combinePdfFileListDto.FilePaths)
            //        {
            //            reader = new PdfReader(file);
            //            pdf.AddDocument(reader);
            //            reader.Close();
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        if (reader != null)
            //        {
            //            reader.Close();
            //        }
            //        throw e;
            //    }
            //    finally
            //    {
            //        if (document != null)
            //        {
            //            document.Close();
            //        }
            //    }
            //}

            combinePdfFileListReturnType.FilePath = outputFilePath;
            return combinePdfFileListReturnType;
        }
    }
}
