/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.enterMode = CKEDITOR.ENTER_BR;
    config.toolbar = 'Full';
    config.filebrowserBrowseUrl = '/Assets/admin/libs/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/admin/libs/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/admin/libs/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Assets/admin/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Assets/admin/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Assets/admin/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserWindowWidth = '1000';
    config.filebrowserWindowHeight = '700';

    config.extraPlugins = 'widget,lineutils,fontawesome';
    config.contentsCss = '/Assets/admin/libs/ckeditor/plugins/fontawesome/font-awesome/css/font-awesome.min.css';
    config.allowedContent = true;

   // config.scayt_autoStartup = false;
   // config.removePlugins = 'scayt';



    //config.toolbar = [
    //{ name: 'insert', items: ['FontAwesome', 'Source'] }
    //];


};
CKEDITOR.dtd.$removeEmpty['span'] = false;