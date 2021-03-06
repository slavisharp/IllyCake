/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	config.language = 'bg';
    config.toolbarGroups = [
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'clipboard', groups: ['clipboard', 'undo', 'cleanup'] },
        { name: 'links', groups: ['links'] },
        { name: 'others', groups: ['others'] },
        { name: 'tools', groups: ['tools'] },
        '/',
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'basicstyles', groups: ['basicstyles'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        '/',
        { name: 'insert', groups: ['insert'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] }
    ];

    config.removeButtons = 'Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Flash,Print,SelectAll,Scayt,Replace,Language,PageBreak';

    config.extraPlugins = 'uploadimage';
    config.uploadUrl = '/Admin/Images/UploadPostImage';
};