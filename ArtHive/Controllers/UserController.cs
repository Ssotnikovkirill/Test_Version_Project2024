using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[HttpPost("picture/{pictureUrl}")]
public async Task<IActionResult> ChangePicture(string pictureUrl)
{
    // код здесь
}

[HttpPost("rewritepost/{postNum}")]
public async Task<IActionResult> RewritePost(int postNum, [FromBody] Post post)
{
    // код здесь
}

[HttpPost("description/{newDescription}")]
public async Task<IActionResult> ChangeDescription(string newDescription)
{
    // код здесь
}
