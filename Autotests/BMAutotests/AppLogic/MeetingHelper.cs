using AutoItX3Lib;
using BMAutotests.Model;
using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BMAutotests.AppLogic
{
    public class MeetingHelper
    {
        private AppManager app;
        private PageManager pages;
        
        public MeetingHelper(AppManager app)
        {
            this.app = app;
            this.pages = app.Pages;
        }

        public void createMeeting(Meeting meeting)
        {
            pages.meetingsPage.ensurePageLoaded();
            pages.meetingsPage.createButtonClick();

            pages.popupPage.ensurePageLoaded();
            pages.meetingPopup.setMeetingType(meeting.Type);
            pages.meetingPopup.setMeetingNumber(meeting.Number);
            pages.popupPage.saveClick();
        }

        public bool compareMeeting(Meeting meeting, Meeting testMeeting)
        {
            throw new NotImplementedException();
        }

        public Meeting getMeeting()
        {
            throw new NotImplementedException();
        }

        public void deleteMeeting()
        {
            throw new NotImplementedException();
        }
    }
}
