using EnjoyingCookingAPI.Controllers;
using EnjoyingCookingAPI.Models;
using EnjoyingCookingAPI.Validation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EnjoyingUnitTesting
{    
    public class UserControllerTest
    {
        private UserValidator userValidator = new UserValidator();

        [Theory]
        [InlineData("rab@gmail.com", true)]
        [InlineData("iwag@gmail.com", true)]
        [InlineData("mrexyha@gmail.com", true)]
        [InlineData("i@vangmail@gmai.com", false)]
        [InlineData("iambest@gmail.com", true)]
        [InlineData("formanypoints@gmail...com", false)]
        [InlineData("@@gmail...", false)]
        public void CheckEmailPatternTest(string email, bool expected)
        {    
            // Assertion
            Assert.Equal(expected, userValidator.CheckEmailPattern(email));
        }


        [Theory]
        [InlineData("rertykjtdeyktyketykjetyjteyjetdyjetdyjab@gmail.com", false)]
        [InlineData("adshsrtjhtjdrjywag@gmail.com", true)]
        [InlineData("mrexydtyrjtyjahsaehaserhha@gmail.com", false)]
        [InlineData("i@vandrfjydrjytdrjtyrdtjrdjtyrdjtrdjgmail@gmai.com", false)]
        [InlineData("iamedtryjteytjrdtjrdtjjtdyjtdyyjtdybest@gmail.com", false)]
        [InlineData("formanypoints@gmail...com", true)]
        [InlineData("srtjdrjkdtrykdtykdtykdtyk@gmail.com", false)]
        public void CheckEmailLengthTest(string email, bool expected)
        {
            // Assertion
            Assert.Equal(expected, userValidator.CheckEmailLength(email));
        }

        [Theory]
        [InlineData("R2560346d523", true)]
        [InlineData("123456789\\\\", false)]
        [InlineData("sehHJse1245235", true)]
        [InlineData("r2s7e3", true)]
        [InlineData("6aSGrh22?;'", false)]
        [InlineData("makesuccDSGiwhpassword2163", true)]
        [InlineData("3476347@&#$sgsaFgra", false)]
        public void CheckPasswordPatternTest(string password, bool expected)
        {
            // Assertion
            Assert.Equal(expected, userValidator.CheckPasswordPattern(password));
        }

        [Theory]
        [InlineData("R2560346d523", true)]
        [InlineData("1234", false)]
        [InlineData("sehrtse1245235", true)]
        [InlineData("r2s7e3", false)]
        [InlineData("78awerh22", true)]
        [InlineData("makesuccesstiwhpassword2163", true)]
        [InlineData("3476347sgsagra", true)]
        public void CheckPasswordLengthTest(string password, bool expected)
        {
            // Assertion
            Assert.Equal(expected, userValidator.CheckPasswordLength(password));
        }
    }
}
