using BMAutotests.Model;
using BMAutotests.Pages;
using System;
using LumiSoft.Net.IMAP.Client;
using LumiSoft.Net.IMAP;
using LumiSoft.Net;
using LumiSoft.Net.Mail;

namespace BMAutotests.AppLogic
{
    public class EmailHelper
    {
        public EmailMessage currentEmail;
        public IMAP_Client client;
        public EmailHelper()
        {
            currentEmail = new EmailMessage();
            //  client = new IMAP_Client();
        }

        #region method connect
        /// <summary>
        /// Get connect from yandex.
        /// </summary>
        /// <param name="login">Login from email.</param>
        /// <param name="password">Password from email.</param>
        public void connect(string login, string password)
        {
            client = new IMAP_Client();
            client.Connect("imap.yandex.ru", 993, true);
            client.Login(login, password);
            Console.Out.WriteLine("метод connect");
        }
        #endregion
        public void disconnect()
        {
            client.Disconnect();
            //client.Dispose();
            Console.Out.WriteLine("метод disconnect");
        }

        /*
                public void marksUnread(IMAP_Client client, IMAP_Client_FetchHandler fetchHandler)
                {
                     IMAP_SequenceSet sequence = new IMAP_SequenceSet();
                    //sequence.Parse("*:1"); // from first to last
                    // the best way to find unread emails is to perform server search
                    int[] unseen_ids = client.Search(false, "UTF-8", "unseen");
                    Console.WriteLine("unseen count: " + unseen_ids.Count().ToString());
                    // now we need to initiate our sequence of messages to be fetched
                    sequence.Parse(string.Join(",", unseen_ids));
                    // fetch messages now
                    client.Fetch(false, sequence, new IMAP_Fetch_DataItem[] { new IMAP_Fetch_DataItem_Envelope() }, fetchHandler);
                    // uncomment this line to mark messages as read
                    // client.StoreMessageFlags(false, sequence, IMAP_Flags_SetType.Add, IMAP_MessageFlags.Seen);
   
                }*/

        #region method LoadFolderMessages

        /// <summary>
        /// Gets specified folder messages list from IMAP server and adds them to UI.
        /// </summary>
        /// <param name="folder">IMAP folder which messages to load.</param>
        private void LoadFolderMessages(IMAP_Client m_pImap, string folder)
        {
            try
            {
                m_pImap.SelectFolder(folder);
                // No messages in folder, skip fetch.
                if (m_pImap.SelectedFolder.MessagesCount == 0)
                {
                    return;
                }
                // Start fetching.
                m_pImap.Fetch(
                    false,
                    IMAP_t_SeqSet.Parse("*"),
                    new IMAP_t_Fetch_i[]{
                        new IMAP_t_Fetch_i_Envelope(),
                        new IMAP_t_Fetch_i_Flags(),
                        new IMAP_t_Fetch_i_InternalDate(),
                        new IMAP_t_Fetch_i_Rfc822Size(),
                        new IMAP_t_Fetch_i_Uid()
                    }, m_pImap_Fetch_MessageItems_UntaggedResponse
                );
            }
            catch (Exception x)
            {
                Console.WriteLine(x.ToString());
            }
        }

        private void LoadMessage(IMAP_Client m_pImap, string folder)
        {
            try
            {//uid.ToString()
                m_pImap.SelectFolder(folder);
                // Start fetching.
                m_pImap.Fetch(
                    true,
                    IMAP_t_SeqSet.Parse("*"),//последнее письмо должно быть
                    new IMAP_t_Fetch_i[]{
                        new IMAP_t_Fetch_i_Rfc822()
                    },
                     this.m_pImap_Fetch_Message_UntaggedResponse
                );
            }
            catch (Exception x)
            {
                Console.WriteLine("ЭКСЕПШН" + x.ToString() + "ЗАКОНЧИЛСЯ");
            }
        }

        #endregion

        #region method m_pImap_Fetch_MessageItems_UntaggedResponse

        /// <summary>
        /// This method is called when FETCH (Envelope Flags InternalDate Rfc822Size Uid) untagged response is received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event data.</param>
        private void m_pImap_Fetch_MessageItems_UntaggedResponse(object sender, EventArgs<IMAP_r_u> e)
        {
            /* NOTE: All IMAP untagged responses may be raised from thread pool thread,
                so all UI operations must use Invoke.
             
               There may be other untagged responses than FETCH, because IMAP server
               may send any untagged response to any command.
            */

            try
            {
                if (e.Value is IMAP_r_u_Fetch)
                {
                    IMAP_r_u_Fetch fetchResp = (IMAP_r_u_Fetch)e.Value;
                    try
                    {
                        string from = "";
                        if (fetchResp.Envelope.From != null)
                        {
                            for (int i = 0; i < fetchResp.Envelope.From.Length; i++)
                            {
                                // Don't add ; for last item
                                if (i == fetchResp.Envelope.From.Length - 1)
                                {
                                    from += fetchResp.Envelope.From[i].ToString();
                                }
                                else
                                {
                                    from += fetchResp.Envelope.From[i].ToString() + ";";
                                }
                            }
                        }
                        else
                        {
                            from = "<none>";
                        }
                        Console.WriteLine("From {0}", from);
                        Console.WriteLine("Тема письма {0}", fetchResp.Envelope.Subject != null ? fetchResp.Envelope.Subject : "<none>");
                        Console.WriteLine("Внутренняя тема {0}", fetchResp.InternalDate.Date.ToString("dd.MM.yyyy HH:mm"));
                        Console.WriteLine("Размер в килобайтах {0}", ((decimal)(fetchResp.Rfc822Size.Size / (decimal)1000)).ToString("f2") + " kb");
                        Console.WriteLine("UID {0}", fetchResp.UID.UID.ToString());
                        Console.WriteLine("UID1 {0}", fetchResp.UID.UID);
                        Console.WriteLine("UID1 {0}", fetchResp.Rfc822Text.Stream);

                    }
                    catch (Exception x)
                    {
                        Console.WriteLine("Error: " + x.ToString(), "Error:");
                    }

                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: " + x.ToString(), "Error:");
            }
        }

        #endregion

        #region method m_pImap_Fetch_Message_UntaggedResponse

        /// <summary>
        /// This method is called when FETCH RFC822 untagged response is received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event data.</param>
        private void m_pImap_Fetch_Message_UntaggedResponse(object sender, EventArgs<IMAP_r_u> e)
        {
            /* NOTE: All IMAP untagged responses may be raised from thread pool thread,
                so all UI operations must use Invoke.
             
               There may be other untagged responses than FETCH, because IMAP server
               may send any untagged response to any command.
            */

            try
            {
                if (e.Value is IMAP_r_u_Fetch)
                {
                    IMAP_r_u_Fetch fetchResp = (IMAP_r_u_Fetch)e.Value;
                    try
                    {
                        fetchResp.Rfc822.Stream.Position = 0;
                        Mail_Message mime = Mail_Message.ParseFromStream(fetchResp.Rfc822.Stream);
                        fetchResp.Rfc822.Stream.Dispose();
                        /*
                                                    m_pTabPageMail_MessagesToolbar.Items["save"].Enabled = true;
                                                    m_pTabPageMail_MessagesToolbar.Items["delete"].Enabled = true;

                                                    m_pTabPageMail_MessageAttachments.Tag = mime;
                                                    foreach (MIME_Entity entity in mime.Attachments)
                                                    {
                                                        ListViewItem item = new ListViewItem();
                                                        if (entity.ContentDisposition != null && entity.ContentDisposition.Param_FileName != null)
                                                        {
                                                            item.Text = entity.ContentDisposition.Param_FileName;
                                                        }
                                                        else
                                                        {
                                                            item.Text = "untitled";
                                                        }
                                                        item.ImageIndex = 0;
                                                        item.Tag = entity;
                                                        m_pTabPageMail_MessageAttachments.Items.Add(item);
                                                    }*/

                        if (mime.Subject != null)
                        {
                            currentEmail.subject = mime.Subject;
                            currentEmail.message = mime.BodyHtmlText;
                            currentEmail.from = mime.From.ToString();
                            currentEmail.date = mime.Date.ToShortDateString();
                            currentEmail.to = mime.To.ToString();
                        }
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine("Error: " + x.ToString(), "Error:");
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: " + x.ToString(), "Error:");
            }
        }

        #endregion

        #region method getEmail

        /// <summary>
        /// Get all email in folder.
        /// </summary>
        /// <param name="folder">IMAP folder which messages to load. Default INBOX</param>
        public EmailMessage getEmail(string folder)
        {

            // client.SelectFolder("INBOX");
            //LoadFolderMessages(connect(login,password),folder);
            // LoadFolders(connect(login, password));
            currentEmailClear();
            LoadMessage(client, folder);// пока не надо получать текст сообщения, достаточно заголовков
            return currentEmail;
        }
        public void currentEmailClear()
        {
            currentEmail.subject = null;
            currentEmail.message = null;
            currentEmail.from = null;
            currentEmail.date = null;
            currentEmail.to = null;
            currentEmail.links.Clear();
        }

        #endregion
        public void DeleteCurrentMessage()
        {
            //throw new NotImplementedException();
        }

        public bool TimeOffEmail(EmailMessage message)
        {
            return message.subject == "второе письмо";
        }
        #region mehtod LoadFolders

        /// <summary>
        /// Loads IMAP server folders to UI.
        /// </summary>
        private void LoadFolders(IMAP_Client m_pImap)
        {

            IMAP_r_u_List[] folders = m_pImap.GetFolders(null);

            char folderSeparator = m_pImap.FolderSeparator;
            foreach (IMAP_r_u_List folder in folders)
            {
                string[] folderPath = folder.FolderName.Split(folderSeparator);
                Console.WriteLine(folder.FolderName);
                // Conatins sub folders.
                if (folderPath.Length > 1)
                {
                    string currentPath = "";
                    foreach (string fold in folderPath)
                    {
                        if (currentPath.Length > 0)
                        {
                            Console.WriteLine(currentPath, fold);
                            currentPath += "/" + fold;
                        }
                        else
                        {
                            Console.WriteLine(currentPath, fold);
                            currentPath = fold;
                        }
                    }
                }
            }
        }

        #endregion

        public bool CompareEmail(EmailMessage EM1, EmailMessage EM2)
        {
            UserHelper.WriteToConsole(EM1, EM2);
            return EM1.subject == EM2.subject &&
            EM1.date.Contains(EM2.date) &&
            EM1.from.Contains(EM2.from) &&
            EM1.to.Contains(EM2.to) &&
            EM1.bcc == EM2.bcc &&
            EM1.contextTitle == EM2.contextTitle &&
            EM1.contextMaintext.Contains(EM2.contextMaintext) &&
            EM1.contextFooter == EM2.contextFooter &&
            EM1.bestregards == EM2.bestregards &&
            UserHelper.listComparisionLinks(EM1.links, EM2.links);
        }
        public EmailMessage parseTextMessage(EmailMessage EM)
        {
            EmailsPage EP = new EmailsPage();
            EM = EP.getContextEmailByType(EM);
            return EM;
        }
    }
}
