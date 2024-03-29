import ImgMissingLink from '/public/images/missing-link.jpg?jsx';
import Notes from '~/components/template/notes'
import { component$ } from "@builder.io/qwik";

export default component$(() => {
    return <>
        <Notes title='You Found the Missing Link'>
        This page seems to have gone the way of the dodo (or maybe just the yeti). But fret not, intrepid explorer, the [birdseye-view](/docs/birdseye-view/) or [getting-started](/docs/getting-started/) might have the answers you're searching for.
        </Notes>
        <div class="w-full flex justify-items-center">
            <ImgMissingLink class="mx-auto w-64 h-64 rounded-full" />
        </div>
        <div class="border-t-2 mt-4 pt-5">
            Click <a href="/">Home</a> to find your way back.
        </div>
    </>
});