function RenderRSS() {
    $("#rss-default").rss("https://powerapps.microsoft.com/en-us/blog/feed/").show();

    $("#rss-styled").rss("https://powerapps.microsoft.com/en-us/blog/feed/", {
        limit: 5,
        layoutTemplate: '<dl class="dl-horizontal">{entries}</dl>',
        entryTemplate: '<dt><a href="{url}">{title}</a></dt><dd>{shortBodyPlain}[{author}@{date}]</dd>'
    }).show();

    $("#rss-metro").rss("https://powerapps.microsoft.com/en-us/blog/feed/", {
        limit: 4,
        layoutTemplate: '<span id="entries">{entries}</span>',
        entryTemplate: '<a href="{url}">{title}</a>|'
    }).show();
}

function onLoad() {
    jQuery(function ($) {
        $("#rss-feeds").rss("https://powerapps.microsoft.com/en-us/blog/feed/",
            {
                entryTemplate: '<li><a href="{url}">[{author}@{date}] {title}</a><br/>{teaserImage}{shortBodyPlain}</li>'
            })
    });
}